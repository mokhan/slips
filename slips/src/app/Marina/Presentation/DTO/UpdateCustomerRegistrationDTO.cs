using System;

namespace Marina.Presentation.DTO {
	[Serializable]
	public class UpdateCustomerRegistrationDTO {
		private long customerId;
		private string username;
		private string password;
		private string firstName;
		private string lastName;
		private string phoneNumber;
		private string city;

		public UpdateCustomerRegistrationDTO( long customerId, string username, string password, string firstName,
		                                      string lastName, string phoneNumber, string city ) {
			this.customerId = customerId;
			this.username = username;
			this.password = password;
			this.firstName = firstName;
			this.lastName = lastName;
			this.phoneNumber = phoneNumber;
			this.city = city;
		}

		public long CustomerId {
			get { return customerId; }
		}

		public string Username {
			get { return username; }
		}

		public string Password {
			get { return password; }
		}

		public string FirstName {
			get { return firstName; }
		}

		public string LastName {
			get { return lastName; }
		}

		public string PhoneNumber {
			get { return phoneNumber; }
		}

		public string City {
			get { return city; }
		}
	}
}