using System.Collections.Generic;
using System.Text;

namespace Marina.DataAccess.Builders {
	public static class DatabaseInsert {
		public static IInsertQueryBuilder Into( string tableName ) {
			return new InsertQueryBuilder( tableName );
		}

		private class InsertQueryBuilder : IInsertQueryBuilder {
			public InsertQueryBuilder( string tableName ) {
				_tableName = tableName;
				_parameters = new List< DatabaseCommandParameter >( );
			}

			public IEnumerable< DatabaseCommandParameter > Parameters() {
				return _parameters;
			}

			public IQuery Build() {
				return new Query( this );
			}

			public IInsertQueryBuilder AddValue< T >( DatabaseColumn column, T value ) {
				_parameters.Add( new DatabaseCommandParameter( column.ColumnName, value ) );
				return this;
			}

			public override string ToString() {
				StringBuilder builder = new StringBuilder( );
				builder.AppendFormat( "INSERT INTO {0} ({1}) VALUES ({2});SELECT @@IDENTITY;", _tableName,
				                      GetParameterNames( string.Empty ),
				                      GetParameterNames( "@" ) );
				return builder.ToString( );
			}

			private string GetParameterNames( string prefix ) {
				StringBuilder builder = new StringBuilder( );
				foreach ( DatabaseCommandParameter parameter in _parameters ) {
					builder.AppendFormat( "{0}{1},", prefix, parameter.ColumnName );
				}
				builder.Remove( builder.Length - 1, 1 );
				return builder.ToString( );
			}

			private readonly string _tableName;
			private readonly IList< DatabaseCommandParameter > _parameters;
		}
	}
}