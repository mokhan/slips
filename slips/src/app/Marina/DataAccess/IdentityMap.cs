using System.Collections.Generic;
using Marina.DataAccess.Exceptions;
using Marina.Domain.Interfaces;

namespace Marina.DataAccess {
	public class IdentityMap< T > : IIdentityMap< T > where T : IDomainObject {
		public IdentityMap() {
			_items = new List< T >( );
		}

		public void Add( T domainObject ) {
			EnsureObjectHasNotAlreadyBeenAdded( domainObject );
			_items.Add( domainObject );
		}

		public bool ContainsObjectWithIdOf( long idOfObjectToFind ) {
			foreach ( T item in _items ) {
				if ( item.ID( ).Equals( idOfObjectToFind ) ) {
					return true;
				}
			}
			return false;
		}

		public T FindObjectWithIdOf( long idOfObjectToFind ) {
			foreach ( T item in _items ) {
				if ( item.ID( ).Equals( idOfObjectToFind ) ) {
					return item;
				}
			}
			return default( T );
		}

		private void EnsureObjectHasNotAlreadyBeenAdded( T domainObject ) {
			if ( ContainsObjectWithIdOf( domainObject.ID( ) ) ) {
				throw new ObjectAlreadyAddedToIdentityMapException( domainObject );
			}
		}

		private readonly IList< T > _items;
	}
}