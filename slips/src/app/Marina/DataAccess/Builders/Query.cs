using System.Data;

namespace Marina.DataAccess.Builders {
	public class Query : IQuery {
		public Query( IQueryBuilder builder ) {
			_builder = builder;
		}

		public void Prepare( IDbCommand command ) {
			command.CommandText = _builder.ToString( );
			command.CommandType = CommandType.Text;
			foreach ( DatabaseCommandParameter parameter in _builder.Parameters( ) ) {
				IDataParameter commandParameter = command.CreateParameter( );
				commandParameter.ParameterName = "@" + parameter.ColumnName;
				commandParameter.Value = parameter.Value;
				command.Parameters.Add( commandParameter );
			}
		}

		private readonly IQueryBuilder _builder;
	}
}