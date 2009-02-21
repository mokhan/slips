using System.Collections.Generic;
using Marina.Domain.Interfaces;

namespace Marina.Domain.Interfaces {
	public interface IRegistration {
		string Username();

		string Password();

		string FirstName();

		string LastName();

		string PhoneNumber();

		string City();

		bool IsValid();

		IEnumerable< IBrokenRule > BrokenRules();
	}
}