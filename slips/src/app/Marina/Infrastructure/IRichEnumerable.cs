using System.Collections.Generic;

namespace Marina.Infrastructure {
	public interface IRichEnumerable< T > : IEnumerable< T > {
		IEnumerable< T > Where( ISpecification< T > criteriaToSatisfy );
	}
}