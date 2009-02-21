namespace Marina.DataAccess {
	public class DatabaseCommandParameter {
		public DatabaseCommandParameter( string columnName, object value ) {
			_columnName = columnName;
			_value = value;
		}

		public string ColumnName {
			get { return _columnName; }
		}

		public object Value {
			get { return _value; }
		}

		private readonly string _columnName;
		private readonly object _value;
	}
}