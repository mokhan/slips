using Marina.Presentation;

namespace Marina.Web {
	public interface IHttpRequest {
		T ParsePayloadFor< T >( PayloadKey< T > key );
	}
}