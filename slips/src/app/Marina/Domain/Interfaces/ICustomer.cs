using System;
using System.Collections.Generic;

namespace Marina.Domain.Interfaces {
	public interface ICustomer : IDomainObject {
		void RegisterBoat( string registrationNumber, string manufacturer, DateTime yearOfModel, long length );

		void RegisterBoat( IBoat unregisteredBoat );

		IEnumerable< IBoat > RegisteredBoats();

		void Lease( ISlip slip, ILeaseDuration duration );

		IEnumerable< ISlipLease > Leases();

		IRegistration Registration();

		void RegisterAccount( string username, string password, string firstName,
		                      string lastName, string phoneNumber, string city );

		void UpdateRegistrationTo( IRegistration registration );

		void UpdateRegistrationTo( string username, string password, string firstName, string lastName,
		                                  string phoneNumber,
		                                  string city );
	}
}