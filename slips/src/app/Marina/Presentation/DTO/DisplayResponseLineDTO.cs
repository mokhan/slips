using System;

namespace Marina.Presentation.DTO {
	[Serializable]
	public class DisplayResponseLineDTO : IEquatable< DisplayResponseLineDTO > {
		private readonly string _message;

		private DisplayResponseLineDTO() {}

		public DisplayResponseLineDTO( string message ) {
			_message = message;
		}

		public string Message {
			get { return _message; }
		}

		public bool Equals( DisplayResponseLineDTO displayResponseLineDTO ) {
			if ( displayResponseLineDTO == null ) {
				return false;
			}
			return Equals( _message, displayResponseLineDTO._message );
		}

		public override bool Equals( object obj ) {
			if ( ReferenceEquals( this, obj ) ) {
				return true;
			}
			return Equals( obj as DisplayResponseLineDTO );
		}

		public override int GetHashCode() {
			return _message != null ? _message.GetHashCode( ) : 0;
		}
	}
}