namespace Marina.DataAccess.Builders {
	public interface IUpdateQueryBuilder : IQueryBuilder {
		IUpdateQueryBuilder Add( DatabaseColumn column, string value );
	}
}