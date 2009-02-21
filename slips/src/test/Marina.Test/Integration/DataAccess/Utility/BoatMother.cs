using Marina.DataAccess;
using Marina.DataAccess.Builders;
using Marina.DataAccess.Schemas;
using Marina.Infrastructure.Container;

namespace Marina.Test.Integration.DataAccess.Utility {
	public static class BoatMother {
		public static void AddBoatsFor( long customerId ) {
			IInsertQueryBuilder builder = DatabaseInsert.Into( BoatTable.TableName )
				.AddValue( BoatTable.RegistrationNumber, string.Empty )
				.AddValue( BoatTable.Manufacturer, string.Empty )
				.AddValue( BoatTable.ModelYear, string.Empty )
				.AddValue( BoatTable.Length, string.Empty )
				.AddValue( BoatTable.CustomerID, customerId.ToString( ) );

			Resolve.DependencyFor< IDatabaseGateway >( ).Execute( builder.Build( ), builder.Build( ), builder.Build( ) );
		}
	}
}