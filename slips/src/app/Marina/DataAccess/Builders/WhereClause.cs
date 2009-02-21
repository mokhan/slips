namespace Marina.DataAccess.Builders {
	public class WhereClause {
		public WhereClause( DatabaseColumn column, string value ) {
			_column = column;
			_value = value;
		}

		public DatabaseColumn Column() {
			return _column;
		}

		public string Value() {
			return _value;
		}

		public string ToSql() {
			return ToString( );
		}

		public override string ToString() {
			return string.Format( " WHERE [{0}].[{1}] = {2};", _column.TableName, _column.ColumnName, _value );
		}

		private readonly DatabaseColumn _column;
		private readonly string _value;
	}
}