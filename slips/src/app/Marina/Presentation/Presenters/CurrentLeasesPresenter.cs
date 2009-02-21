using Marina.Infrastructure.Container;
using Marina.Presentation.Views;
using Marina.Task;
using Marina.Web;

namespace Marina.Presentation.Presenters {
	public class CurrentLeasesPresenter : ICurrentLeasesPresenter {
		public CurrentLeasesPresenter( ICurrentLeasesView view )
			: this( view, Resolve.DependencyFor< IHttpRequest >( ), Resolve.DependencyFor< ILeaseTasks >( ) ) {}

		public CurrentLeasesPresenter( ICurrentLeasesView view, IHttpRequest request, ILeaseTasks task ) {
			_view = view;
			_request = request;
			_task = task;
		}

		public void Initialize() {
			_view.Display( _task.FindAllLeasesFor( _request.ParsePayloadFor( PayloadKeys.CustomerId ) ) );
		}

		private readonly ICurrentLeasesView _view;
		private readonly IHttpRequest _request;
		private readonly ILeaseTasks _task;
	}
}