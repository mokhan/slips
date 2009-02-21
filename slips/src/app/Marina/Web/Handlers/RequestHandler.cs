using Marina.Infrastructure;
using Marina.Web.Http;

namespace Marina.Web.Handlers {
	public class RequestHandler : IRequestHandler {
		public RequestHandler( ISpecification< IHttpGateway > specification, ICommand command ) {
			_specification = specification;
			_command = command;
		}

		public bool IsSatisfiedBy( IHttpGateway item ) {
			return _specification.IsSatisfiedBy( item );
		}

		public void Execute() {
			_command.Execute( );
		}

		public static ISpecification< IHttpGateway > For( string commandName ) {
			return new RequestHandlerSpecification( commandName );
		}

		private readonly ISpecification< IHttpGateway > _specification;
		private readonly ICommand _command;
	}
}