using Marina.Infrastructure;
using Marina.Web.Http;

namespace Marina.Web.Handlers {
	public class RequestHandlerSpecification : ISpecification< IHttpGateway > {
		private readonly string _commandName;

		public RequestHandlerSpecification( string commandName ) {
			_commandName = commandName;
		}

		public bool IsSatisfiedBy( IHttpGateway item ) {
			return item.Destination( ).Contains( _commandName );
		}
	}
}