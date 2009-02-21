using System.Collections.Generic;
using System.Data;
using Marina.DataAccess.Builders;
using Marina.Infrastructure;
using Marina.Infrastructure.Container;

namespace Marina.DataAccess {
	public class DatabaseGateway : IDatabaseGateway {
		private readonly IDatabaseConnectionFactory _connectionFactory;

		public DatabaseGateway() : this( Resolve.DependencyFor< IDatabaseConnectionFactory >( ) ) {}

		public DatabaseGateway( IDatabaseConnectionFactory connectionFactory ) {
			_connectionFactory = connectionFactory;
		}

		public DataTable LoadTableUsing( string sqlQuery ) {
			using ( IDatabaseConnection connection = _connectionFactory.Create( ) ) {
				IDatabaseCommand command = connection.CreateCommandFor( sqlQuery );
				return ( null != command ) ? command.ExecuteQuery( ) : null;
			}
		}

		public IEnumerable< IDatabaseRow > FindAllRowsMatching( IQuery query ) {
			using ( IDatabaseConnection connection = _connectionFactory.Create( ) ) {
				DataTable table = connection.CreateCommandFor( query ).ExecuteQuery( );
				if ( null != table ) {
					foreach ( DataRow row in table.Rows ) {
						yield return new DatabaseRow( row );
					}
				}
			}
		}

		public void Execute( params IQuery[] queries ) {
			Execute( ListFactory.From( queries ) );
		}

		public void Execute( IEnumerable< IQuery > queries ) {
			using ( IDatabaseConnection connection = _connectionFactory.Create( ) ) {
				foreach ( IQuery query in queries ) {
					connection.CreateCommandFor( query ).ExecuteQuery( );
				}
			}
		}

		public long ExecuteScalar( IQuery query ) {
			using ( IDatabaseConnection connection = _connectionFactory.Create( ) ) {
				return connection.CreateCommandFor( query ).ExecuteScalarQuery( );
			}
		}

		public IDatabaseRow LoadRowUsing( IQuery query ) {
			using ( IDatabaseConnection connection = _connectionFactory.Create( ) ) {
				DataTable table = connection.CreateCommandFor( query ).ExecuteQuery( );
				return table.Rows.Count > 0 ? new DatabaseRow( table.Rows[ 0 ] ) : DatabaseRow.Blank;
			}
		}
	}
}