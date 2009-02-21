using Marina.Domain.Interfaces;
using Marina.Presentation.DTO;

namespace Marina.Task.Mappers {
	public class LeaseToDtoMapper : ILeaseToDtoMapper {
		public DisplayLeaseDTO MapFrom( ISlipLease input ) {
			return new DisplayLeaseDTO( input.Slip( ).ID( ).ToString( ),
			                            input.StartDate( ).ToString( ),
			                            input.ExpiryDate( ).ToString( ) );
		}
	}
}