using Marina.Infrastructure.Container;
using Marina.Presentation.Mappers;
using Marina.Presentation.Views;
using Marina.Task;
using Marina.Web;

namespace Marina.Presentation.Presenters {
	public class UpdateCustomerRegistrationPresenter : IUpdateCustomerRegistrationPresenter {
		public UpdateCustomerRegistrationPresenter( IUpdateRegistrationView view ) :
			this(
			view,
			Resolve.DependencyFor< IHttpRequest >( ),
			Resolve.DependencyFor< IRegistrationTasks >( ),
			Resolve.DependencyFor< IUpdateRegistrationPresentationMapper >( )
			) {}

		public UpdateCustomerRegistrationPresenter( IUpdateRegistrationView view, IHttpRequest request,
		                                            IRegistrationTasks task,
		                                            IUpdateRegistrationPresentationMapper mapper ) {
			_request = request;
			_view = view;
			_task = task;
			_mapper = mapper;
		}

		public void Initialize() {
			_view.Display( _task.LoadRegistrationFor( CustomerId( ) ) );
		}

		public void UpdateRegistration() {
			_view.Display( _task.UpdateRegistrationFor( _mapper.MapFrom( _request ) ) );
			Initialize( );
		}

		private long CustomerId() {
			return _request.ParsePayloadFor( PayloadKeys.CustomerId );
		}

		private readonly IUpdateRegistrationView _view;
		private readonly IRegistrationTasks _task;
		private readonly IUpdateRegistrationPresentationMapper _mapper;
		private readonly IHttpRequest _request;
	}
}