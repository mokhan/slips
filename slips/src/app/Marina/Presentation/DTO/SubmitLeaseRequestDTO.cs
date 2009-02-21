using System;

namespace Marina.Presentation.DTO {
	[Serializable]
	public class SubmitLeaseRequestDTO : IEquatable< SubmitLeaseRequestDTO > {
		private SubmitLeaseRequestDTO() {}

		public SubmitLeaseRequestDTO( long customerId, long slipId, string duration ) {
			_customerId = customerId;
			_slipId = slipId;
			_duration = duration;
		}

		public long CustomerId {
			get { return _customerId; }
		}

		public long SlipId {
			get { return _slipId; }
		}

		public string Duration {
			get { return _duration; }
		}

		public bool Equals( SubmitLeaseRequestDTO submitLeaseRequestDTO ) {
			if ( submitLeaseRequestDTO == null ) {
				return false;
			}
			if ( _customerId != submitLeaseRequestDTO._customerId ) {
				return false;
			}
			if ( _slipId != submitLeaseRequestDTO._slipId ) {
				return false;
			}
			if ( !Equals( _duration, submitLeaseRequestDTO._duration ) ) {
				return false;
			}
			return true;
		}

		public override bool Equals( object obj ) {
			if ( ReferenceEquals( this, obj ) ) {
				return true;
			}
			return Equals( obj as SubmitLeaseRequestDTO );
		}

		public override int GetHashCode() {
			int result = ( int )_customerId;
			result = 29*result + ( int )_slipId;
			result = 29*result + ( _duration != null ? _duration.GetHashCode( ) : 0 );
			return result;
		}

		private readonly long _customerId;
		private readonly long _slipId;
		private readonly string _duration;
	}
}