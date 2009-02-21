namespace Marina.Presentation {
	public class PayloadKeys {
		public static PayloadKey< long > DockId = new PayloadKey< long >( "DID" );
		public static PayloadKey< long > LocationId = new PayloadKey< long >( "LID" );
		public static PayloadKey< long > CustomerId = new PayloadKey< long >( "CID" );
		public static PayloadKey< long > SlipId = new PayloadKey< long >( "SID" );

		public static PayloadKey< string > For( string controlId ) {
			return new PayloadKey< string >( controlId );
		}
	}
}