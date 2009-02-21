using System;
using Marina.DataAccess;
using Marina.DataAccess.Builders;
using Marina.DataAccess.Schemas;
using Marina.Infrastructure.Container;

namespace Marina.Test.Integration.DataAccess.Utility {
	public static class LeaseMother {
		public static void CreateLeaseFor( long customerId ) {
			IQuery query = DatabaseInsert
				.Into( LeaseTable.TableName )
				.AddValue( LeaseTable.CustomerID, customerId )
				.AddValue( LeaseTable.EndDate, DateTime.Now.AddDays( 1 ) )
				.AddValue( LeaseTable.LeaseTypeID, 1 )
				.AddValue( LeaseTable.SlipID, SlipMother.CreateSlip( ) )
				.AddValue( LeaseTable.StartDate, DateTime.Now ).Build( );

			Resolve.DependencyFor< IDatabaseGateway >( ).Execute( query );
		}
	}
}