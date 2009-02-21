using Marina.DataAccess;
using Marina.DataAccess.Builders;
using Marina.DataAccess.Schemas;
using Marina.Infrastructure.Container;

namespace Marina.Test.Integration.DataAccess.Utility {
	public static class CustomerMother {
		public static long CreateCustomerRecord() {
			IInsertQueryBuilder builder = DatabaseInsert.Into( CustomerTable.TableName )
				.AddValue( CustomerTable.FirstName, string.Empty )
				.AddValue( CustomerTable.LastName, string.Empty )
				.AddValue( CustomerTable.Phone, string.Empty )
				.AddValue( CustomerTable.City, string.Empty );
			return Resolve.DependencyFor< IDatabaseGateway >( ).ExecuteScalar( builder.Build( ) );
		}

		public static long CreateCustomerRecordWith( string username ) {
			IInsertQueryBuilder builder = DatabaseInsert.Into( CustomerTable.TableName )
				.AddValue( CustomerTable.FirstName, string.Empty )
				.AddValue( CustomerTable.LastName, string.Empty )
				.AddValue( CustomerTable.Phone, string.Empty )
				.AddValue( CustomerTable.City, string.Empty );
			long customerId = Resolve.DependencyFor< IDatabaseGateway >( ).ExecuteScalar( builder.Build( ) );

			IQuery insertToAuthTable = DatabaseInsert.Into( AuthorizationTable.TableName )
				.AddValue( AuthorizationTable.UserName, username )
				.AddValue( AuthorizationTable.Password, string.Empty )
				.Build( );

			Resolve.DependencyFor< IDatabaseGateway >( ).Execute( insertToAuthTable );
			return customerId;
		}
	}
}