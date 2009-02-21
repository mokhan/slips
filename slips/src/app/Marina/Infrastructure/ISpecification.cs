namespace Marina.Infrastructure {
	public interface ISpecification< T > {
		bool IsSatisfiedBy( T item );
	}
}