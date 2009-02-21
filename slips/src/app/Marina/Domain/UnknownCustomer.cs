using System;
using System.Collections.Generic;
using Marina.Domain.Interfaces;

namespace Marina.Domain {
	public class UnknownCustomer : ICustomer {
		public void RegisterBoat( string registrationNumber, string manufacturer, DateTime yearOfModel, long length ) {}

		public void RegisterBoat( IBoat unregisteredBoat ) {}

		public IEnumerable< IBoat > RegisteredBoats() {
			return new List< IBoat >( );
		}

		public void Lease( ISlip slip, ILeaseDuration duration ) {}

		public IEnumerable< ISlipLease > Leases() {
			return new List< ISlipLease >( );
		}

		public IRegistration Registration() {
			return CustomerRegistration.BlankRegistration( );
		}

		public void RegisterAccount( string username, string password, string firstName, string lastName, string phoneNumber,
		                             string city ) {}

		public void UpdateRegistrationTo( IRegistration registration ) {}

		public void UpdateRegistrationTo( string username, string password, string firstName, string lastName,
		                                  string phoneNumber, string city ) {}

		public long ID() {
			return -1;
		}

		public void ChangeIdTo( long id ) {}
	}
}