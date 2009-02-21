using System;
using Marina.Domain.Interfaces;

namespace Marina.Domain {
	public class Boat : DomainObject, IBoat, IEquatable< Boat > {
		public Boat( string registrationNumber, string manufacturer, DateTime yearOfModel, long length )
			: this( -1, registrationNumber, manufacturer, yearOfModel, length ) {}

		public Boat( long id, string registrationNumber, string manufacturer, DateTime yearOfModel, long length )
			: base( id ) {
			_registrationNumber = registrationNumber;
			_manufacturer = manufacturer;
			_yearOfModel = yearOfModel;
			_length = length;
		}

		public string RegistrationNumber() {
			return _registrationNumber;
		}

		public string Manufacturer() {
			return _manufacturer;
		}

		public DateTime YearOfModel() {
			return _yearOfModel;
		}

		public long LengthInFeet() {
			return _length;
		}

		public bool Equals( Boat boat ) {
			if ( boat == null ) {
				return false;
			}
			if ( !Equals( _registrationNumber, boat._registrationNumber ) ) {
				return false;
			}
			if ( !Equals( _manufacturer, boat._manufacturer ) ) {
				return false;
			}
			if ( !Equals( _yearOfModel, boat._yearOfModel ) ) {
				return false;
			}
			if ( _length != boat._length ) {
				return false;
			}
			return true;
		}

		public override bool Equals( object obj ) {
			if ( ReferenceEquals( this, obj ) ) {
				return true;
			}
			return Equals( obj as Boat );
		}

		public override int GetHashCode() {
			int result = _registrationNumber != null ? _registrationNumber.GetHashCode( ) : 0;
			result = 29*result + ( _manufacturer != null ? _manufacturer.GetHashCode( ) : 0 );
			result = 29*result + _yearOfModel.GetHashCode( );
			result = 29*result + ( int )_length;
			return result;
		}

		private readonly string _registrationNumber;
		private readonly string _manufacturer;
		private readonly DateTime _yearOfModel;
		private readonly long _length;
	}
}