using System.Data;

namespace Marina.DataAccess.Builders {
	public class SqlQuery : IQuery {
		public SqlQuery( string sqlQuery ) {
			_sqlQuery = sqlQuery;
		}

		public void Prepare( IDbCommand command ) {
			if ( command != null ) {
				command.CommandText = _sqlQuery;
				command.CommandType = CommandType.Text;
			}
		}

		private readonly string _sqlQuery;
	}
}