using System;

namespace Marina.Domain.Interfaces {
	public interface IBoat : IDomainObject {
		string RegistrationNumber();

		string Manufacturer();

		DateTime YearOfModel();

		long LengthInFeet();
	}
}