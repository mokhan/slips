using Marina.Infrastructure.Container;
using Marina.Presentation.Mappers;
using Marina.Presentation.Views;
using Marina.Task;

namespace Marina.Presentation.Presenters {
	public class CustomerRegistrationPresenter : ICustomerRegistrationPresenter {
		private readonly ICustomerRegistrationView _view;
		private readonly ICustomerRegistrationPresentationMapper _mapper;
		private readonly IRegistrationTasks _task;

		public CustomerRegistrationPresenter( ICustomerRegistrationView view ) : this(
			view,
			Resolve.DependencyFor< ICustomerRegistrationPresentationMapper >( ),
			Resolve.DependencyFor< IRegistrationTasks >( )
			) {}

		public CustomerRegistrationPresenter( ICustomerRegistrationView view,
		                                      ICustomerRegistrationPresentationMapper mapper,
		                                      IRegistrationTasks task ) {
			_view = view;
			_mapper = mapper;
			_task = task;
		}

		public void RegisterCustomer( ) {
			_view.Display( _task.RegisterNew( _mapper.MapFrom( _view ) ) );
		}
	}
}