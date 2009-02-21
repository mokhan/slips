using System.Web;
using Marina.Web.Handlers;
using Marina.Web.Http;

namespace Marina.Web {
	public class FrontController : IHttpHandler {
		public FrontController( IHttpGateway gateway ) {
			_gateway = gateway;
		}

		public void ProcessRequest( HttpContext context ) {
			new Dispatcher( ).FindFor( _gateway ).Execute( );
		}

		public bool IsReusable {
			get { return true; }
		}

		private IHttpGateway _gateway;
	}
}