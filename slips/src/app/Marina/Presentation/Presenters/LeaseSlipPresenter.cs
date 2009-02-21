using Marina.Infrastructure.Container;
using Marina.Presentation.Mappers;
using Marina.Presentation.Views;
using Marina.Task;
using Marina.Web;

namespace Marina.Presentation.Presenters {
	public class LeaseSlipPresenter : ILeaseSlipPresenter {
		public LeaseSlipPresenter( ILeaseSlipView view )
			: this(
				view,
				Resolve.DependencyFor< IHttpRequest >( ),
				Resolve.DependencyFor< ICatalogTasks >( ),
				Resolve.DependencyFor< ILeaseTasks >( ),
				Resolve.DependencyFor< ILeaseRequestDtoFromHttpRequestMapper >( )
				) {}

		public LeaseSlipPresenter( ILeaseSlipView view, IHttpRequest request, ICatalogTasks task, ILeaseTasks leaseTask,
		                           ILeaseRequestDtoFromHttpRequestMapper mapper ) {
			_view = view;
			_request = request;
			_task = task;
			_leaseTask = leaseTask;
			_mapper = mapper;
		}

		public void Initialize() {
			_view.Display( _task.FindSlipBy( _request.ParsePayloadFor( PayloadKeys.SlipId ) ) );
		}

		public void SubmitLeaseRequest() {
			_view.Display( _leaseTask.RequestLeaseUsing( _mapper.MapFrom( _request ) ) );
		}

		private readonly ILeaseSlipView _view;
		private readonly IHttpRequest _request;
		private readonly ICatalogTasks _task;
		private readonly ILeaseTasks _leaseTask;
		private readonly ILeaseRequestDtoFromHttpRequestMapper _mapper;
	}
}