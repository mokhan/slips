using System.Collections.Generic;
using Marina.Domain;
using Marina.Domain.Exceptions;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using Marina.Infrastructure;
using Marina.Presentation.DTO;
using Marina.Task.Mappers;

namespace Marina.Task {
	public class LeaseTasks : ILeaseTasks {
		public LeaseTasks( ICustomerRepository customers, ISlipsRepository slips, ILeaseToDtoMapper mapper ) {
			_customers = customers;
			_slips = slips;
			_mapper = mapper;
		}

		public IEnumerable< DisplayLeaseDTO > FindAllLeasesFor( long customerId ) {
			return new EnumerableMapper< ISlipLease, DisplayLeaseDTO >( _mapper )
				.MapFrom( _customers.FindBy( customerId ).Leases( ) );
		}

		public DisplayResponseLineDTO RequestLeaseUsing( SubmitLeaseRequestDTO request ) {
			ICustomer customer = _customers.FindBy( request.CustomerId );
			try {
				customer.Lease( _slips.FindBy( request.SlipId ), LeaseDurations.FindBy( request.Duration ) );
				_customers.Save( customer );
				return new DisplayResponseLineDTO( "Success!" );
			}
			catch ( SlipIsAlreadyLeasedException ) {
				return new DisplayResponseLineDTO( "Slip is already leased!" );
			}
		}

		private readonly ICustomerRepository _customers;
		private readonly ISlipsRepository _slips;
		private readonly ILeaseToDtoMapper _mapper;
	}
}