using System.Collections.Generic;
using System.Text;

namespace Marina.DataAccess.Builders {
	public static class DatabaseSelect {
		public static ISelectQueryBuilder From( string tableName ) {
			return new SelectQueryBuilder( tableName );
		}

		private class SelectQueryBuilder : ISelectQueryBuilder {
			public SelectQueryBuilder( string tableName ) {
				_tableName = string.Format( "[{0}]", tableName );
				_innerJoins = new List< InnerJoin >( );
				_selectColumns = new List< DatabaseColumn >( );
			}

			public ISelectQueryBuilder AddColumn( DatabaseColumn column ) {
				_selectColumns.Add( column );
				return this;
			}

			public ISelectQueryBuilder InnerJoinOn( DatabaseColumn leftColumn, DatabaseColumn rightColumn ) {
				_innerJoins.Add( new InnerJoin( leftColumn, rightColumn ) );
				return this;
			}

			public ISelectQueryBuilder Where( DatabaseColumn column, string value ) {
				_whereClause = new WhereClause( column, value );
				return this;
			}

			public ISelectQueryBuilder Where< T >( DatabaseColumn column, T value ) {
				return Where( column, value.ToString( ) );
			}

			public override string ToString() {
				return
					string.Format( "SELECT {0} FROM {1} {2} {3};", GetColumnNames( ), _tableName, GetInnerJoins( ), _whereClause );
			}

			public IEnumerable< DatabaseCommandParameter > Parameters() {
				foreach ( DatabaseColumn databaseColumn in _selectColumns ) {
					yield return new DatabaseCommandParameter( databaseColumn.ColumnName, string.Empty );
				}
			}

			public IQuery Build() {
				return new Query( this );
			}

			private string GetInnerJoins() {
				StringBuilder builder = new StringBuilder( );
				foreach ( InnerJoin innerJoin in _innerJoins ) {
					builder.Append( innerJoin.ToString( ) );
				}
				return builder.ToString( );
			}

			private string GetColumnNames() {
				StringBuilder builder = new StringBuilder( );
				foreach ( DatabaseColumn selectColumn in _selectColumns ) {
					builder.AppendFormat( "{0},", selectColumn );
				}
				builder.Remove( builder.Length - 1, 1 );
				return builder.ToString( );
			}

			private readonly string _tableName;
			private readonly IList< DatabaseColumn > _selectColumns;
			private readonly IList< InnerJoin > _innerJoins;
			private WhereClause _whereClause;

			private class InnerJoin : IJoin {
				public InnerJoin( DatabaseColumn leftColumn, DatabaseColumn rightColumn ) {
					_leftColumn = leftColumn;
					_rightColumn = rightColumn;
				}

				public DatabaseColumn Left() {
					return _leftColumn;
				}

				public DatabaseColumn Right() {
					return _rightColumn;
				}

				public override string ToString() {
					return
						string.Format( "INNER JOIN [{0}] ON [{0}].[{1}] = [{2}].[{3}]",
						               _leftColumn.TableName,
						               _leftColumn.ColumnName,
						               _rightColumn.TableName,
						               _rightColumn.ColumnName );
				}

				private readonly DatabaseColumn _leftColumn;
				private readonly DatabaseColumn _rightColumn;
			}
		}
	}
}