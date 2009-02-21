using System.Collections.Generic;
using Marina.DataAccess.DataMappers;
using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Infrastructure;
using Marina.Test.Integration.DataAccess.Utility;
using Marina.Test.Utility;
using MbUnit.Framework;

namespace Marina.Test.Integration.DataAccess.Mappers {
	[TestFixture]
	public class LeaseDataMapperTest {
		public ILeaseDataMapper CreateSUT() {
			return new LeaseDataMapper( );
		}

		[Test]
		[RollBack]
		[RunInRealContainer]
		public void Should_return_all_leases_for_a_specific_customer() {
			long customerId = CustomerMother.CreateCustomerRecord( );
			LeaseMother.CreateLeaseFor( customerId );

			IRichList< ISlipLease > leasesForCustomer = ListFactory.From( CreateSUT( ).AllLeasesFor( customerId ) );
			Assert.AreEqual( 1, leasesForCustomer.Count );
		}

		[Test]
		[RollBack]
		[RunInRealContainer]
		public void Should_be_able_to_insert_new_leases_for_customer() {
			long customerId = CustomerMother.CreateCustomerRecord( );

			IList< ISlipLease > leases = new List< ISlipLease >( );
			leases.Add( new SlipLease( new Slip( 1000, null, 100, 100, true ), LeaseDurations.Daily ) );

			ILeaseDataMapper mapper = CreateSUT( );
			mapper.Insert( leases, customerId );

			IRichList< ISlipLease > foundLeases = ListFactory.From( mapper.AllLeasesFor( customerId ) );
			Assert.AreEqual( 1, foundLeases.Count );
		}
	}
}