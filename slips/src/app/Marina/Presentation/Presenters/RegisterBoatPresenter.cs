using Marina.Infrastructure.Container;
using Marina.Presentation.Mappers;
using Marina.Presentation.Views;
using Marina.Task;
using Marina.Web;

namespace Marina.Presentation.Presenters {
	public class RegisterBoatPresenter : IRegisterBoatPresenter {
		public RegisterBoatPresenter( IRegisterBoatView view )
			: this( view,
			        Resolve.DependencyFor< IHttpRequest >( ),
			        Resolve.DependencyFor< IRegistrationTasks >( ),
			        Resolve.DependencyFor< INewBoatRegistrationMapper >( )
				) {}

		public RegisterBoatPresenter( IRegisterBoatView view, IHttpRequest request, IRegistrationTasks task,
		                              INewBoatRegistrationMapper mapper ) {
			_view = view;
			_request = request;
			_task = task;
			_mapper = mapper;
		}

		public void SubmitRegistration() {
			_view.Display( _task.AddNewBoatUsing( _mapper.MapFrom( _request ) ) );
		}

		private readonly IRegisterBoatView _view;
		private readonly IHttpRequest _request;
		private readonly IRegistrationTasks _task;
		private readonly INewBoatRegistrationMapper _mapper;
	}
}