using System.Collections.Generic;
using System.Web.Services;
using Marina.Infrastructure.Container;
using Marina.Presentation.DTO;
using Marina.Task;

namespace Marina.Web.Services {
	public class CatalogWebServices {
		public CatalogWebServices() : this( Resolve.DependencyFor< ICatalogTasks >( ) ) {}

		public CatalogWebServices( ICatalogTasks underlyingTask ) {
			_underlyingTask = underlyingTask;
		}

		public IEnumerable< SlipDisplayDTO > GetAvailableSlipsForDockBy( long dockId ) {
			return _underlyingTask.GetAvailableSlipsForDockBy( dockId );
		}

		[WebMethod]
		public DockDisplayDTO GetDockInformationBy( long dockId ) {
			return _underlyingTask.GetDockInformationBy( dockId );
		}

		public IEnumerable< SlipDisplayDTO > GetAllAvailableSlips() {
			return _underlyingTask.GetAllAvailableSlips( );
		}

		[WebMethod]
		public SlipDisplayDTO FindSlipBy( long slipId ) {
			return _underlyingTask.FindSlipBy( slipId );
		}

		private readonly ICatalogTasks _underlyingTask;
	}
}