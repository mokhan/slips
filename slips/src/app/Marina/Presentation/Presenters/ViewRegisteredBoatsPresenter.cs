using Marina.Infrastructure.Container;
using Marina.Presentation.Views;
using Marina.Task;
using Marina.Web;

namespace Marina.Presentation.Presenters {
	public class ViewRegisteredBoatsPresenter : IViewRegisteredBoatsPresenter {
		public ViewRegisteredBoatsPresenter( IRegisteredBoatsView view )
			: this( view, Resolve.DependencyFor< IRegistrationTasks >( ), Resolve.DependencyFor< IHttpRequest >( ) ) {}

		public ViewRegisteredBoatsPresenter( IRegisteredBoatsView view, IRegistrationTasks task, IHttpRequest request ) {
			_view = view;
			_task = task;
			_request = request;
		}

		public void Initialize() {
			_view.Display( _task.AllBoatsFor( _request.ParsePayloadFor( PayloadKeys.CustomerId ) ) );
		}

		private readonly IRegisteredBoatsView _view;
		private readonly IRegistrationTasks _task;
		private readonly IHttpRequest _request;
	}
}