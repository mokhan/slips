namespace Marina.DataAccess {
	public class DatabaseConnectionFactory : IDatabaseConnectionFactory {
		public IDatabaseConnection Create() {
			return new DatabaseConnection( );
		}
	}
}