namespace Marina.Infrastructure {
	public interface IVisitor< T > {
		void Visit( T item );
	}
}