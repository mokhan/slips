using System.Collections.Generic;
using Marina.Presentation.DTO;

namespace Marina.Task {
	public interface ICatalogTasks {
		IEnumerable< SlipDisplayDTO > GetAvailableSlipsForDockBy( long dockId );

		DockDisplayDTO GetDockInformationBy( long dockId );

		IEnumerable< SlipDisplayDTO > GetAllAvailableSlips();

		SlipDisplayDTO FindSlipBy( long slipId );
	}
}