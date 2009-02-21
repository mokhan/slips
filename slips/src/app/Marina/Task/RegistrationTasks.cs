using System;
using System.Collections.Generic;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using Marina.Infrastructure.Container;
using Marina.Presentation.DTO;
using Marina.Task.Mappers;

namespace Marina.Task {
	public class RegistrationTasks : IRegistrationTasks {
		public RegistrationTasks()
			: this(
				Resolve.DependencyFor< IBrokenRulesToDisplayItemMapper >( ),
				Resolve.DependencyFor< ICustomerRepository >( )
				) {}

		public RegistrationTasks( IBrokenRulesToDisplayItemMapper mapper, ICustomerRepository customers ) {
			_mapper = mapper;
			_customers = customers;
		}

		public IEnumerable< DisplayResponseLineDTO > RegisterNew( RegisterCustomerDTO customer ) {
			if ( null == _customers.FindBy( customer.UserName ) ) {
				ICustomer newCustomer = _customers.NewCustomer( );
				newCustomer.RegisterAccount( customer.UserName,
				                             customer.Password,
				                             customer.FirstName,
				                             customer.LastName,
				                             customer.Phone,
				                             customer.City );
				if ( !newCustomer.Registration( ).IsValid( ) ) {
					return _mapper.MapFrom( newCustomer.Registration( ).BrokenRules( ) );
				}
				else {
					_customers.Save( newCustomer );
					return new DisplayResponseLines( "Success!" );
				}
			}
			else {
				return
					new DisplayResponseLines(
						string.Format( "The username {0} is already taken. Please try another!", customer.UserName ) );
			}
		}

		public IEnumerable< DisplayResponseLineDTO > AddNewBoatUsing( BoatRegistrationDTO boat ) {
			ICustomer customer = _customers.FindBy( boat.CustomerId );
			customer.RegisterBoat( boat.RegistrationNumber,
			                       boat.Manufacturer,
			                       new DateTime( Convert.ToInt32( boat.ModelYear ), 1, 1 ),
			                       Convert.ToInt64( boat.Length ) );
			_customers.Save( customer );
			return new DisplayResponseLines( "Success!" );
		}

		public CustomerRegistrationDisplayDTO LoadRegistrationFor( long customerId ) {
			IRegistration registration = _customers.FindBy( customerId ).Registration( );
			return
				new CustomerRegistrationDisplayDTO( customerId.ToString( ),
				                                    registration.Username( ),
				                                    registration.FirstName( ),
				                                    registration.LastName( ),
				                                    registration.PhoneNumber( ),
				                                    registration.City( )
					);
		}

		public IEnumerable< DisplayResponseLineDTO > UpdateRegistrationFor( UpdateCustomerRegistrationDTO registration ) {
			ICustomer customer = _customers.FindBy( registration.CustomerId );

			customer.UpdateRegistrationTo( registration.Username, registration.Password, registration.FirstName,
			                               registration.LastName, registration.PhoneNumber, registration.City );
			if ( customer.Registration( ).IsValid( ) ) {
				_customers.Save( customer );
			}
			return _mapper.MapFrom( customer.Registration( ).BrokenRules( ) );
		}

		public IEnumerable< BoatRegistrationDTO > AllBoatsFor( long customerId ) {
			ICustomer customer = _customers.FindBy( customerId );

			foreach ( IBoat boat in customer.RegisteredBoats( ) ) {
				yield return
					new BoatRegistrationDTO( boat.RegistrationNumber( ), boat.Manufacturer( ), boat.YearOfModel( ).ToString( ),
					                         boat.LengthInFeet( ).ToString( ), customerId );
			}
		}

		private readonly IBrokenRulesToDisplayItemMapper _mapper;
		private readonly ICustomerRepository _customers;
	}
}