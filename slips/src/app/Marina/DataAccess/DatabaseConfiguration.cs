using System.Configuration;

namespace Marina.DataAccess {
	public class DatabaseConfiguration : IDatabaseConfiguration {
		private readonly ConnectionStringSettings _connectionSettings;

		public DatabaseConfiguration()
			: this( ConfigurationManager.ConnectionStrings[ ConfigurationManager.AppSettings[ "ActiveConnection" ] ] ) {}

		public DatabaseConfiguration( ConnectionStringSettings connectionSettings ) {
			_connectionSettings = connectionSettings;
		}

		public string ConnectionString() {
			return _connectionSettings.ConnectionString;
		}

		public string ProviderName() {
			return _connectionSettings.ProviderName;
		}
	}
}