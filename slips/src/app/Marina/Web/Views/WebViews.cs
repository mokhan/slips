using Marina.Web.Views.Pages;

namespace Marina.Web.Views {
	public class WebViews {
		public static readonly IAvailableSlipsWebView AvailableSlips = new AvailableSlipsWebView( );

		public static readonly IView ContactUs = new View( "ContactUs.aspx" );
		public static readonly IView Default = new View( "Default.aspx" );
		public static readonly IView DockView = new View( "DockView.aspx" );
		public static readonly IView Login = new View( "Login.aspx" );
		public static readonly IView RegisterBoat = new View( "RegisterBoat.aspx" );
		public static readonly IView Registration = new View( "Registration.aspx" );
		public static readonly IView UpdateCustomerRegistration = new View( "UpdateCustomerRegistration.aspx" );
		public static readonly IView ViewRegisteredBoats = new View( "ViewRegisteredBoats.aspx" );
		public static readonly IView CurrentLeases = new View( "CurrentLeases.aspx" );
		public static readonly IView LeaseSlip = new View( "LeaseSlip.aspx" );
	}
}