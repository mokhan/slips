using System.Data;
using System.Data.Common;

namespace Marina.DataAccess {
	public class DatabaseProviderFactory : IDatabaseProviderFactory {
		public IDbConnection CreateConnectionFor( string providerName ) {
			return DbProviderFactories.GetFactory( providerName ).CreateConnection( );
		}
	}
}