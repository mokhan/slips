using System;
using System.Collections;
using System.Collections.Generic;

namespace Marina.Presentation.DTO {
	[Serializable]
	public class DisplayResponseLines : IEnumerable< DisplayResponseLineDTO > {
		private readonly string[] _lineItems;

		public DisplayResponseLines( params string[] messages ) {
			_lineItems = messages;
		}

		IEnumerator< DisplayResponseLineDTO > IEnumerable< DisplayResponseLineDTO >.GetEnumerator() {
			foreach ( string message in _lineItems ) {
				yield return new DisplayResponseLineDTO( message );
			}
		}

		public IEnumerator GetEnumerator() {
			return ( ( IEnumerable< DisplayResponseLineDTO > )this ).GetEnumerator( );
		}
	}
}