using System;

namespace Marina.Presentation {
	public class PayloadKeyNotFoundException : Exception {
		public PayloadKeyNotFoundException( string key ) : base( "The payload key could not be found: " + key ) {}
	}
}