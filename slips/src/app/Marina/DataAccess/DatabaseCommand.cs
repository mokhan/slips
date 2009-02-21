using System;
using System.Data;

namespace Marina.DataAccess {
	public class DatabaseCommand : IDatabaseCommand {
		public DatabaseCommand( IDbCommand command ) {
			_command = command;
		}

		public DataTable ExecuteQuery() {
			DataTable table = new DataTable( );
			table.Load( _command.ExecuteReader( ) );
			return table;
		}

		public long ExecuteScalarQuery() {
			object scalar = _command.ExecuteScalar( );
			return DBNull.Value != scalar ? Convert.ToInt32( scalar ) : -1;
		}

		private readonly IDbCommand _command;
	}
}