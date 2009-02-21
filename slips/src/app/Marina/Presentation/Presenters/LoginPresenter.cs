using Marina.Infrastructure.Container;
using Marina.Presentation.Mappers;
using Marina.Presentation.Views;
using Marina.Task;
using Marina.Web;

namespace Marina.Presentation.Presenters {
	public class LoginPresenter : ILoginPresenter {
		public LoginPresenter( ILoginView view )
			: this(
				view,
				Resolve.DependencyFor< IHttpRequest >( ),
				Resolve.DependencyFor< IAuthenticationTask >( ),
				Resolve.DependencyFor< ILoginCredentialsMapper >( )
				) {}

		public LoginPresenter( ILoginView view, IHttpRequest request, IAuthenticationTask task,
		                       ILoginCredentialsMapper mapper ) {
			_view = view;
			_request = request;
			_task = task;
			_mapper = mapper;
		}

		public void Login() {
			_view.Display( _task.AuthenticateUserUsing( _mapper.MapFrom( _request ) ) );
		}

		private readonly ILoginView _view;
		private readonly IHttpRequest _request;
		private readonly IAuthenticationTask _task;
		private readonly ILoginCredentialsMapper _mapper;
	}
}