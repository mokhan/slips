using System.Collections.Generic;
using System.Web.Services;
using Marina.Infrastructure.Container;
using Marina.Presentation.DTO;
using Marina.Task;

namespace Marina.Web.Services {
	public class LeaseWebServices {
		public LeaseWebServices() : this( Resolve.DependencyFor< ILeaseTasks >( ) ) {}

		public LeaseWebServices( ILeaseTasks underlyingTask ) {
			_underlyingTask = underlyingTask;
		}

		public IEnumerable< DisplayLeaseDTO > FindAllLeasesFor( long customerId ) {
			return _underlyingTask.FindAllLeasesFor( customerId );
		}

		[WebMethod]
		public DisplayResponseLineDTO RequestLeaseUsing( SubmitLeaseRequestDTO request ) {
			return _underlyingTask.RequestLeaseUsing( request );
		}

		private readonly ILeaseTasks _underlyingTask;
	}
}