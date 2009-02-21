namespace Marina.Infrastructure {
	public interface ISpecificationBuilder< T > : ISpecification< T > {
		ISpecificationBuilder< T > And( ISpecification< T > specification );
	}
}