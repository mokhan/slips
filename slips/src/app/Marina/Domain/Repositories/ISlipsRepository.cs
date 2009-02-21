using System.Collections.Generic;
using Marina.Domain.Interfaces;

namespace Marina.Domain.Repositories {
	public interface ISlipsRepository {
		IEnumerable< ISlip > AllAvailableSlips();

		IEnumerable< ISlip > AllAvailableSlipsFor( IDock dock );

		ISlip FindBy( long slipId );
	}
}