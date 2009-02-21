namespace Marina.DataAccess.Builders {
	public interface IInsertQueryBuilder : IQueryBuilder {
		IInsertQueryBuilder AddValue< T >( DatabaseColumn column, T value );
	}
}