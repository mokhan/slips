using Marina.Infrastructure;
using Marina.Web.Commands;
using Marina.Web.Http;

namespace Marina.Web.Handlers {
	public class Dispatcher {
		private readonly IRegisteredHandlers handlers;

		public Dispatcher() : this( new RegisteredHandlers( ) ) {}

		public Dispatcher( IRegisteredHandlers handlers ) {
			this.handlers = handlers;
		}

		public ICommand FindFor( IHttpGateway request ) {
			foreach ( IRequestHandler handler in handlers.All( ) ) {
				if ( handler.IsSatisfiedBy( request ) ) {
					return handler;
				}
			}
			return new RedirectCommand( );
		}
	}
}