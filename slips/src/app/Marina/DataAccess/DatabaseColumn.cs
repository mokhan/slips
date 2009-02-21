namespace Marina.DataAccess {
	public class DatabaseColumn {
		internal DatabaseColumn( string tableName, string columnName ) {
			_tableName = tableName;
			_columnName = columnName;
		}

		public string TableName {
			get { return _tableName; }
		}

		public string ColumnName {
			get { return _columnName; }
		}

		public override string ToString() {
			return string.Format( "[{0}].[{1}]", _tableName, _columnName );
		}

		private readonly string _tableName;
		private readonly string _columnName;
	}
}