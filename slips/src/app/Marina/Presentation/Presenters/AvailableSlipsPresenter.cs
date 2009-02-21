using Marina.Infrastructure.Container;
using Marina.Presentation.Views;
using Marina.Task;

namespace Marina.Presentation.Presenters {
	public class AvailableSlipsPresenter : IAvailableSlipsPresenter {
		private readonly IAvailableSlipsView view;
		private readonly ICatalogTasks task;

		public AvailableSlipsPresenter( IAvailableSlipsView view )
			: this(
				view,
				Resolve.DependencyFor< ICatalogTasks >( )
				) {}

		public AvailableSlipsPresenter( IAvailableSlipsView view, ICatalogTasks task ) {
			this.view = view;
			this.task = task;
		}

		public void Initialize() {
			view.Display( task.GetAllAvailableSlips( ) );
		}
	}
}