using System.Collections.Generic;
using System.Text;

namespace Marina.DataAccess.Builders {
	public static class DatabaseUpdate {
		public static IUpdateQueryBuilder Where< T >( DatabaseColumn whereColumn, T whereValue ) {
			return new UpdateQueryBuilder( whereColumn, whereValue.ToString( ) );
		}

		private class UpdateQueryBuilder : IUpdateQueryBuilder {
			public UpdateQueryBuilder( DatabaseColumn whereColumn, string whereValue )
				: this( new List< DatabaseCommandParameter >( ), new WhereClause( whereColumn, whereValue ) ) {}

			public UpdateQueryBuilder( IList< DatabaseCommandParameter > parameters, WhereClause where ) {
				_parameters = parameters;
				_where = where;
			}

			public IEnumerable< DatabaseCommandParameter > Parameters() {
				return _parameters;
			}

			public IQuery Build() {
				return new Query( this );
			}

			public IUpdateQueryBuilder Add( DatabaseColumn column, string value ) {
				_parameters.Add( new DatabaseCommandParameter( column.ColumnName, value ) );
				return this;
			}

			public override string ToString() {
				StringBuilder builder = new StringBuilder( );
				builder.AppendFormat( "UPDATE [{0}] SET {1};", _where.Column( ).TableName, GetParameterNames( ) );
				return builder.ToString( );
			}

			private string GetParameterNames() {
				StringBuilder builder = new StringBuilder( );
				foreach ( DatabaseCommandParameter parameter in _parameters ) {
					builder.AppendFormat( "[{0}].[{1}] = @{1},", _where.Column( ).TableName, parameter.ColumnName );
				}
				builder.Remove( builder.Length - 1, 1 );
				builder.Append( _where );
				return builder.ToString( );
			}

			private readonly IList< DatabaseCommandParameter > _parameters;
			private readonly WhereClause _where;
		}
	}
}