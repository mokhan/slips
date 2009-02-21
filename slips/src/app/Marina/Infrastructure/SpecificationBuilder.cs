namespace Marina.Infrastructure {
	public class SpecificationBuilder< T > : ISpecificationBuilder< T > {
		public SpecificationBuilder() : this( new BlankSpecification( ) ) {}

		public SpecificationBuilder( ISpecification< T > criteria ) {
			_criteria = criteria;
		}

		public bool IsSatisfiedBy( T item ) {
			return _criteria.IsSatisfiedBy( item );
		}

		public ISpecificationBuilder< T > And( ISpecification< T > specification ) {
			_criteria = new AndSpecification< T >( _criteria, specification );
			return this;
		}

		public ISpecification< T > Build() {
			return _criteria;
		}

		public class BlankSpecification : ISpecification< T > {
			public bool IsSatisfiedBy( T item ) {
				return true;
			}
		}

		private ISpecification< T > _criteria;

		private class AndSpecification< K > : ISpecification< K > {
			public AndSpecification( ISpecification< K > leftCriteria, ISpecification< K > rightCriteria ) {
				this.leftCriteria = leftCriteria;
				this.rightCriteria = rightCriteria;
			}

			public bool IsSatisfiedBy( K item ) {
				return leftCriteria.IsSatisfiedBy( item ) && rightCriteria.IsSatisfiedBy( item );
			}

			private readonly ISpecification< K > leftCriteria;
			private readonly ISpecification< K > rightCriteria;
		}
	}
}