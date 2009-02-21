using System.Collections.Generic;
using Marina.Presentation.DTO;

namespace Marina.Task {
	public interface ILeaseTasks {
		IEnumerable< DisplayLeaseDTO > FindAllLeasesFor( long customerId );

		DisplayResponseLineDTO RequestLeaseUsing( SubmitLeaseRequestDTO request );
	}
}