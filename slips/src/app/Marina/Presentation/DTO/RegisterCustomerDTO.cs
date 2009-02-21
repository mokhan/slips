using System;

namespace Marina.Presentation.DTO {
	[Serializable]
	public class RegisterCustomerDTO {
		public RegisterCustomerDTO( string userName, string password, string firstName, string lastName, string phone,
		                            string city ) {
			_userName = userName;
			_password = password;
			_firstName = firstName;
			_lastName = lastName;
			_phone = phone;
			_city = city;
		}

		public string UserName {
			get { return _userName; }
		}

		public string Password {
			get { return _password; }
		}

		public string FirstName {
			get { return _firstName; }
		}

		public string LastName {
			get { return _lastName; }
		}

		public string Phone {
			get { return _phone; }
		}

		public string City {
			get { return _city; }
		}

		private string _userName;
		private string _password;
		private string _firstName;
		private string _lastName;
		private string _phone;
		private string _city;
	}
}