using System;

namespace Marina.Presentation.DTO {
	[Serializable]
	public class CustomerRegistrationDisplayDTO : IEquatable< CustomerRegistrationDisplayDTO > {
		private CustomerRegistrationDisplayDTO() {}

		public CustomerRegistrationDisplayDTO( string id, string userName, string firstName, string lastName, string phone,
		                                       string city ) {
			_userName = userName;
			_id = id;
			_firstName = firstName;
			_lastName = lastName;
			_phone = phone;
			_city = city;
		}

		public string Id {
			get { return _id; }
		}

		public string UserName {
			get { return _userName; }
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

		public bool Equals( CustomerRegistrationDisplayDTO customerRegistrationDisplayDTO ) {
			if ( customerRegistrationDisplayDTO == null ) {
				return false;
			}
			if ( !Equals( _userName, customerRegistrationDisplayDTO._userName ) ) {
				return false;
			}
			if ( !Equals( _firstName, customerRegistrationDisplayDTO._firstName ) ) {
				return false;
			}
			if ( !Equals( _lastName, customerRegistrationDisplayDTO._lastName ) ) {
				return false;
			}
			if ( !Equals( _phone, customerRegistrationDisplayDTO._phone ) ) {
				return false;
			}
			if ( !Equals( _city, customerRegistrationDisplayDTO._city ) ) {
				return false;
			}
			if ( !Equals( _id, customerRegistrationDisplayDTO._id ) ) {
				return false;
			}
			return true;
		}

		public override bool Equals( object obj ) {
			if ( ReferenceEquals( this, obj ) ) {
				return true;
			}
			return Equals( obj as CustomerRegistrationDisplayDTO );
		}

		public override int GetHashCode() {
			int result = _userName != null ? _userName.GetHashCode( ) : 0;
			result = 29*result + ( _firstName != null ? _firstName.GetHashCode( ) : 0 );
			result = 29*result + ( _lastName != null ? _lastName.GetHashCode( ) : 0 );
			result = 29*result + ( _phone != null ? _phone.GetHashCode( ) : 0 );
			result = 29*result + ( _city != null ? _city.GetHashCode( ) : 0 );
			result = 29*result + ( _id != null ? _id.GetHashCode( ) : 0 );
			return result;
		}

		private string _userName;
		private string _firstName;
		private string _lastName;
		private string _phone;
		private string _city;
		private string _id;
	}
}