namespace Marina.DataAccess.Builders {
	public interface ISelectQueryBuilder : IQueryBuilder {
		ISelectQueryBuilder AddColumn( DatabaseColumn column );

		ISelectQueryBuilder InnerJoinOn( DatabaseColumn leftColumn, DatabaseColumn rightColumn );

		ISelectQueryBuilder Where( DatabaseColumn column, string value );

		ISelectQueryBuilder Where< T >( DatabaseColumn column, T value );
	}
}