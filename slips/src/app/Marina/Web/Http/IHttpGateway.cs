using Marina.Presentation;
using Marina.Web.Views;

namespace Marina.Web.Http {
	public interface IHttpGateway {
		string Destination();

		void RedirectTo( IView view );

		void AddAuthenticationCookieFor( string username, long customerId );

		bool ContainsPayload< T >( PayloadKey< T > key );

		T ParsePayloadFor< T >( PayloadKey< T > key );
	}
}