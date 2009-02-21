using System.Collections.Specialized;
using Marina.Presentation;

namespace Marina.Web {
	public class CurrentHttpRequest : IHttpRequest {
		public CurrentHttpRequest( IHttpContext context ) {
			_context = context;
		}

		public T ParsePayloadFor< T >( PayloadKey< T > key ) {
			return key.ParseFrom( Payload( ) );
		}

		private NameValueCollection Payload() {
			return new NameValueCollection( _context.Request.Params );
		}

		private readonly IHttpContext _context;
	}
}