using Marina.Domain.Interfaces;
using Marina.Infrastructure;
using Marina.Presentation.DTO;

namespace Marina.Task.Mappers {
	public interface ILeaseToDtoMapper : IMapper< ISlipLease, DisplayLeaseDTO > {}
}