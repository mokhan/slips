using Marina.Infrastructure;
using Marina.Infrastructure.Container;
using Marina.Task;
using Marina.Web.Views.Pages;

namespace Marina.Web.Commands {
	public class AvailableSlipsCommand : ICommand {
		public AvailableSlipsCommand() : this( new AvailableSlipsWebView( ), Resolve.DependencyFor< ICatalogTasks >( ) ) {}

		public AvailableSlipsCommand( IAvailableSlipsWebView view, ICatalogTasks task ) {
			_view = view;
			_task = task;
		}

		public void Execute() {
			_view.AddToBag( _task.GetAllAvailableSlips( ) );
			_view.Render( );
		}

		private readonly IAvailableSlipsWebView _view;
		private readonly ICatalogTasks _task;
	}
}