using System.Web.Services;
using Marina.Infrastructure.Container;
using Marina.Presentation.DTO;
using Marina.Task;

namespace Marina.Web.Services {
	public class AuthenticationWebServices : IAuthenticationTask {
		public AuthenticationWebServices() : this( Resolve.DependencyFor< IAuthenticationTask >( ) ) {}

		public AuthenticationWebServices( IAuthenticationTask realTask ) {
			this.realTask = realTask;
		}

		[WebMethod]
		public DisplayResponseLineDTO AuthenticateUserUsing( LoginCredentialsDTO credentials ) {
			return realTask.AuthenticateUserUsing( credentials );
		}

		private readonly IAuthenticationTask realTask;
	}
}