using System;
using System.Collections.Generic;
using Marina.Domain.Interfaces;

namespace Marina.Domain {
	public class CustomerRegistration : IRegistration, IEquatable< CustomerRegistration > {
		private CustomerRegistration()
			: this( string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty ) {}

		public CustomerRegistration( string userName, string password, string firstName, string lastName, string phoneNumber,
		                             string city ) {
			_userName = userName;
			_password = password;
			_firstName = firstName;
			_lastName = lastName;
			_phoneNumber = phoneNumber;
			_city = city;
		}

		public string Username() {
			return _userName;
		}

		public string Password() {
			return _password;
		}

		public string FirstName() {
			return _firstName;
		}

		public string LastName() {
			return _lastName;
		}

		public string PhoneNumber() {
			return _phoneNumber;
		}

		public string City() {
			return _city;
		}

		public bool IsValid() {
			foreach ( IBusinessRule businessRule in AllRules( ) ) {
				if ( !businessRule.IsBroken( ) ) {
					return false;
				}
			}
			return true;
		}

		public IEnumerable< IBrokenRule > BrokenRules() {
			foreach ( IBusinessRule businessRule in AllRules( ) ) {
				if ( !businessRule.IsBroken( ) ) {
					yield return businessRule.Description( );
				}
			}
		}

		private IEnumerable< IBusinessRule > AllRules() {
			yield return new PasswordRule( _password );
			yield return new UserNameRule( _userName );
		}

		public bool Equals( CustomerRegistration customerRegistration ) {
			if ( customerRegistration == null ) {
				return false;
			}
			if ( !Equals( _userName, customerRegistration._userName ) ) {
				return false;
			}
			if ( !Equals( _password, customerRegistration._password ) ) {
				return false;
			}
			if ( !Equals( _firstName, customerRegistration._firstName ) ) {
				return false;
			}
			if ( !Equals( _lastName, customerRegistration._lastName ) ) {
				return false;
			}
			if ( !Equals( _phoneNumber, customerRegistration._phoneNumber ) ) {
				return false;
			}
			if ( !Equals( _city, customerRegistration._city ) ) {
				return false;
			}
			return true;
		}

		public override bool Equals( object obj ) {
			if ( ReferenceEquals( this, obj ) ) {
				return true;
			}
			return Equals( obj as CustomerRegistration );
		}

		public override int GetHashCode() {
			int result = _userName != null ? _userName.GetHashCode( ) : 0;
			result = 29*result + ( _password != null ? _password.GetHashCode( ) : 0 );
			result = 29*result + ( _firstName != null ? _firstName.GetHashCode( ) : 0 );
			result = 29*result + ( _lastName != null ? _lastName.GetHashCode( ) : 0 );
			result = 29*result + ( _phoneNumber != null ? _phoneNumber.GetHashCode( ) : 0 );
			result = 29*result + ( _city != null ? _city.GetHashCode( ) : 0 );
			return result;
		}

		private readonly string _userName;
		private readonly string _password;
		private readonly string _firstName;
		private readonly string _lastName;
		private readonly string _phoneNumber;
		private readonly string _city;

		private class PasswordRule : IBusinessRule {
			private readonly string _password;

			public PasswordRule( string password ) {
				_password = password;
			}

			public bool IsBroken() {
				return !string.IsNullOrEmpty( _password );
			}

			public IBrokenRule Description() {
				return new BrokenRule( "Password cannot be blank" );
			}
		}

		private class UserNameRule : IBusinessRule {
			private readonly string _userName;

			public UserNameRule( string userName ) {
				_userName = userName;
			}

			public bool IsBroken() {
				return !string.IsNullOrEmpty( _userName );
			}

			public IBrokenRule Description() {
				return new BrokenRule( "Username cannot be blank" );
			}
		}

		public static IRegistration BlankRegistration() {
			return new CustomerRegistration( );
		}
	}
}