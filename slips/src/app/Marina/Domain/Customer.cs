using System;
using System.Collections.Generic;
using Marina.Domain.Exceptions;
using Marina.Domain.Interfaces;
using Marina.Infrastructure;

namespace Marina.Domain {
	public class Customer : DomainObject, ICustomer {
		public Customer()
			: this( -1, new RichList< IBoat >( ), new RichList< ISlipLease >( ), CustomerRegistration.BlankRegistration( ) ) {}

		public Customer( long id, IEnumerable< IBoat > registeredBoats, IEnumerable< ISlipLease > leases,
		                 IRegistration registration ) : base( id ) {
			_registeredBoats = ListFactory.From( registeredBoats );
			_leases = ListFactory.From( leases );
			_registration = registration;
		}

		public IRegistration Registration() {
			return _registration;
		}

		public void RegisterAccount( string username, string password, string firstName, string lastName, string phoneNumber,
		                             string city ) {
			_registration = new CustomerRegistration( username, password, firstName, lastName, phoneNumber, city );
		}

		public void UpdateRegistrationTo( string username, string password, string firstName, string lastName,
		                                  string phoneNumber,
		                                  string city ) {
			UpdateRegistrationTo( new CustomerRegistration( username, password, firstName, lastName, phoneNumber, city ) );
		}

		public void UpdateRegistrationTo( IRegistration registration ) {
			_registration = registration ?? _registration;
		}

		public void RegisterBoat( string registrationNumber, string manufacturer, DateTime yearOfModel, long length ) {
			RegisterBoat( new Boat( registrationNumber, manufacturer, yearOfModel, length ) );
		}

		public void RegisterBoat( IBoat unregisteredBoat ) {
			if ( !IsBoatRegistered( unregisteredBoat ) ) {
				_registeredBoats.Add( unregisteredBoat );
			}
		}

		public IEnumerable< IBoat > RegisteredBoats() {
			return _registeredBoats.All( );
		}

		public void Lease( ISlip slip, ILeaseDuration duration ) {
			EnsureSlipIsNotLeased( slip );
			_leases.Add( slip.LeaseTo( this, duration ) );
		}

		public IEnumerable< ISlipLease > Leases() {
			return _leases.All( );
		}

		private void EnsureSlipIsNotLeased( ISlip slip ) {
			if ( slip.IsLeased( ) ) {
				throw new SlipIsAlreadyLeasedException( );
			}
		}

		private bool IsBoatRegistered( IBoat boat ) {
			return _registeredBoats.Contains( boat );
		}

		private readonly IRichList< IBoat > _registeredBoats;
		private readonly IRichList< ISlipLease > _leases;
		private IRegistration _registration;
		public static readonly ICustomer Unknown = new UnknownCustomer( );
	}
}