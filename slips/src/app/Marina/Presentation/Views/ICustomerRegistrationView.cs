using System.Collections.Generic;
using Marina.Presentation.DTO;

namespace Marina.Presentation.Views {
	public interface ICustomerRegistrationView {
		string UserName( );

		string Password( );

		string FirstName( );

		string LastName( );

		string PhoneNumber( );

		string City( );

		void Display( IEnumerable< DisplayResponseLineDTO > response );
	}
}