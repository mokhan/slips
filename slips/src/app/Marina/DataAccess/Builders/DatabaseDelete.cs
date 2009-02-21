using System.Collections.Generic;

namespace Marina.DataAccess.Builders {
	public static class DatabaseDelete {
		public static IQuery Where< T >( DatabaseColumn column, T equalsValue ) {
			return new DeleteQueryBuilder< T >( column, equalsValue ).Build( );
		}

		private class DeleteQueryBuilder< T > : IDeleteQueryBuilder {
			public DeleteQueryBuilder( DatabaseColumn column, T value ) {
				_column = column;
				_value = value;
			}

			public override string ToString() {
				return string.Format( "DELETE FROM [{0}] WHERE [{0}].[{1}] = @{1};", _column.TableName, _column.ColumnName );
			}

			public IEnumerable< DatabaseCommandParameter > Parameters() {
				yield return new DatabaseCommandParameter( _column.ColumnName, _value );
			}

			public IQuery Build() {
				return new Query( this );
			}

			private readonly DatabaseColumn _column;
			private readonly T _value;
		}
	}
}