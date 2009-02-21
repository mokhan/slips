using System.Data;

namespace Marina.DataAccess {
	public interface IDatabaseProviderFactory {
		IDbConnection CreateConnectionFor( string providerName );
	}
}