namespace Marina.DataAccess {
	public interface IDatabaseRow {
		T From< T >( DatabaseColumn column );
	}
}