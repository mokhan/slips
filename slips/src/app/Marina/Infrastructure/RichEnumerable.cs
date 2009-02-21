using System.Collections;
using System.Collections.Generic;

namespace Marina.Infrastructure {
	public class RichEnumerable< T > : IRichEnumerable< T > {
		private readonly IEnumerable< T > itemsToEnumerate;

		public RichEnumerable( IEnumerable< T > itemsToEnumerate ) {
			this.itemsToEnumerate = itemsToEnumerate;
		}

		public IEnumerable< T > Where( ISpecification< T > criteriaToSatisfy ) {
			foreach ( T item in itemsToEnumerate ) {
				if ( criteriaToSatisfy.IsSatisfiedBy( item ) ) {
					yield return item;
				}
			}
		}

		IEnumerator< T > IEnumerable< T >.GetEnumerator() {
			return itemsToEnumerate.GetEnumerator( );
		}

		public IEnumerator GetEnumerator() {
			return ( ( IEnumerable< T > )this ).GetEnumerator( );
		}
	}
}