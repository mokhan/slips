namespace Marina.Web.Views {
	public class ViewLuggage {
		public static IViewLuggageTransporter< T > TransporterFor< T >( IViewLuggageTicket< T > ticket ) {
			return new ViewLuggageTransporter< T >( ticket );
		}

		public static T ClaimFor< T >( IViewLuggageTicket< T > ticket ) {
			return new ViewLuggageTransporter< T >( ticket ).Value( );
		}
	}
}