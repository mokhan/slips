using System.Collections.Generic;
using Marina.Domain.Interfaces;

namespace Marina.DataAccess.DataMappers {
	public interface ILeaseDataMapper {
		IEnumerable< ISlipLease > AllLeasesFor( long customerId );

		void Insert( IEnumerable< ISlipLease > leases, long forCustomerId );

		void Update( IEnumerable< ISlipLease > leases, long forCustomerId );

		bool IsLeased( long slipId );
	}
}