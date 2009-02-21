using Marina.DataAccess.DataMappers;
using Marina.Domain.Interfaces;
using Marina.Infrastructure;

namespace Marina.DataAccess.DataMappers {
	public interface ISlipDataMapper : IDataMapper< ISlip > {
		IRichEnumerable< ISlip > AllSlips();
	}
}