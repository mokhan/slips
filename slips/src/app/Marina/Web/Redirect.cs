using System.Web;
using Marina.Web.Views;

namespace Marina.Web {
	public class Redirect {
		public static void To( IView page ) {
			HttpContext.Current.Server.Transfer( page.Name( ) );
		}
	}
}