using Marina.DataAccess;
using Marina.DataAccess.Builders;
using Marina.DataAccess.Schemas;
using Marina.Infrastructure.Container;

namespace Marina.Test.Integration.DataAccess.Utility {
	public static class SlipMother {
		public static long CreateSlip() {
			IQuery query = DatabaseInsert
				.Into( SlipTable.TableName )
				.AddValue( SlipTable.DockID, 1 )
				.AddValue( SlipTable.Length, 100 )
				.AddValue( SlipTable.Width, 100 ).Build( );

			return Resolve.DependencyFor< IDatabaseGateway >( ).ExecuteScalar( query );
		}
	}
}