using Marina.Infrastructure.Container;
using Marina.Presentation.Views;
using Marina.Task;
using Marina.Web;

namespace Marina.Presentation.Presenters {
	public class DockPresenter : IDockPresenter {
		public DockPresenter( IDockView view )
			: this(
				view,
				Resolve.DependencyFor< IHttpRequest >( ),
				Resolve.DependencyFor< ICatalogTasks >( )
				) {}

		public DockPresenter( IDockView view, IHttpRequest request, ICatalogTasks task ) {
			_request = request;
			_view = view;
			_task = task;
		}

		public void Initialize() {
			long dockId = _request.ParsePayloadFor( PayloadKeys.DockId );
			_view.Display( _task.GetDockInformationBy( dockId ) );
			_view.Display( _task.GetAvailableSlipsForDockBy( dockId ) );
		}

		private readonly IDockView _view;
		private readonly ICatalogTasks _task;
		private readonly IHttpRequest _request;
	}
}