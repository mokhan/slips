using System.Collections.Generic;
using Marina.Presentation.DTO;

namespace Marina.Presentation.Views {
	public interface ICurrentLeasesView {
		void Display( IEnumerable< DisplayLeaseDTO > leases );
	}
}