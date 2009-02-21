using Marina.Infrastructure.Container;
using Marina.Web.Http;

namespace Marina.Web.Views {
	public class View : IView {
		public View( string name ) : this( name, Resolve.DependencyFor< IHttpGateway >( ) ) {}

		public View( string name, IHttpGateway gateway ) {
			_name = name;
			_gateway = gateway;
		}

		public string Name() {
			return _name;
		}

		public void Render() {
			_gateway.RedirectTo( this );
		}

		public override string ToString() {
			return Name( );
		}

		private readonly string _name;
		private readonly IHttpGateway _gateway;
	}
}