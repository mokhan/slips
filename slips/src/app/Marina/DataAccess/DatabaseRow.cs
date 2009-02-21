using System;
using System.Data;

namespace Marina.DataAccess {
	public class DatabaseRow : IDatabaseRow {
		public DatabaseRow( DataRow row ) {
			_row = row;
		}

		public static readonly IDatabaseRow Blank = new BlankDatabaseRow( );

		public T From< T >( DatabaseColumn column ) {
			return ( T )Convert.ChangeType( _row[ column.ColumnName ], typeof( T ) );
		}

		private readonly DataRow _row;

		public class BlankDatabaseRow : IDatabaseRow {
			public T From< T >( DatabaseColumn column ) {
				return default( T );
			}
		}
	}
}