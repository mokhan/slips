namespace Marina.Infrastructure {
	public interface IValueReturningVisitor< ValueToReturn, T > : IVisitor< T > {
		ValueToReturn GetResult( );
	}
}