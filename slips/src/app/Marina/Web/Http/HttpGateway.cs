using System;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Marina.Infrastructure.Logging.Interfaces;
using Marina.Presentation;
using Marina.Web.Views;

namespace Marina.Web.Http {
	public class HttpGateway : IHttpGateway {
		public HttpGateway( IHttpContext context ) {
			_context = context;
		}

		public string Destination() {
			return _context.Request.RawUrl;
		}

		public void RedirectTo( IView view ) {
			try {
				_context.Server.Transfer( view.Name( ) );
			}
			catch ( Exception ex ) {
				Log.For( this ).CriticalError( ex.StackTrace );
			}
		}

		public void AddAuthenticationCookieFor( string username, long customerId ) {
			AddCookieToResponse( username, customerId );
			BindPrincipalToCurrentThread( username );
		}

		public T ParsePayloadFor< T >( PayloadKey< T > key ) {
			return key.ParseFrom( Payload( ) );
		}

		public bool ContainsPayload< T >( PayloadKey< T > key ) {
			try {
				ParsePayloadFor( key );
				return true;
			}
			catch ( PayloadKeyNotFoundException ) {
				return false;
			}
		}

		private NameValueCollection Payload() {
			return new NameValueCollection( _context.Request.Params );
		}

		private void BindPrincipalToCurrentThread( string username ) {
			_context.User = new GenericPrincipal( new GenericIdentity( username ), new string[] {"Customer"} );
		}

		private void AddCookieToResponse( string username, long customerId ) {
			FormsAuthenticationTicket ticket =
				new FormsAuthenticationTicket( 1, username, DateTime.Now, DateTime.Now.AddMinutes( 20 ), false,
				                               customerId.ToString( ) );

			_context.Response.Cookies.Add( CreateCookieFrom( ticket ) );
			_context.Response.Cookies.Add( new HttpCookie( PayloadKeys.CustomerId, customerId.ToString( ) ) );
		}

		private HttpCookie CreateCookieFrom( FormsAuthenticationTicket ticket ) {
			return new HttpCookie( FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt( ticket ) );
		}

		private IHttpContext _context;
	}
}