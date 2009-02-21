using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Marina.Web {
	public class AuthenticationHttpModule : IHttpModule {
		public void Init( HttpApplication context ) {
			context.AuthenticateRequest += delegate { AuthenticateHttpRequest( ); };
		}

		public void Dispose() {}

		public void AuthenticateHttpRequest() {
			HttpCookie cookie = GetCookieFrom( HttpContext.Current );
			if ( null != cookie ) {
				BindPrincipalToThreadUsing( FormsAuthentication.Decrypt( cookie.Value ).Name );
			}
		}

		private HttpCookie GetCookieFrom( HttpContext context ) {
			return context.Request.Cookies[ FormsAuthentication.FormsCookieName ];
		}

		private void BindPrincipalToThreadUsing( string username ) {
			HttpContext.Current.User = new GenericPrincipal( new GenericIdentity( username ), new string[] {"Customer"} );
		}
	}
}