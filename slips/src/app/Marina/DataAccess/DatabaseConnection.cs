using System;
using System.Data;
using Marina.DataAccess.Builders;

namespace Marina.DataAccess {
	public class DatabaseConnection : IDatabaseConnection {
		private readonly IDbConnection _connection;

		public DatabaseConnection() : this( new DatabaseConfiguration( ), new DatabaseProviderFactory( ) ) {}

		public DatabaseConnection( IDatabaseConfiguration configuration, IDatabaseProviderFactory providerFactory ) {
			_connection = providerFactory.CreateConnectionFor( configuration.ProviderName( ) );
			_connection.ConnectionString = configuration.ConnectionString( );
			_connection.Open( );
		}

		public IDatabaseCommand CreateCommandFor( string sqlQuery ) {
			return CreateCommandFor( new SqlQuery( sqlQuery ) );
		}

		public IDatabaseCommand CreateCommandFor( IQuery query ) {
			IDbCommand command = _connection.CreateCommand( );
			query.Prepare( command );
			return new DatabaseCommand( command );
		}

		public void Dispose() {
			Dispose( true );
			GC.SuppressFinalize( this );
		}

		protected virtual void Dispose( bool disposing ) {
			if ( disposing ) {
				_connection.Close( );
			}
		}
	}
}