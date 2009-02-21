using System.Collections.Generic;

namespace Marina.Infrastructure {
	public class ListFactory {
		public static IRichList< T > From< T >( IEnumerable< T > items ) {
			if ( items == null ) {
				return new RichList< T >( );
			}
			return new RichList< T >( items );
		}

		public static IEnumerable< T > For< T >( params T[] items ) {
			IRichList< T > list = new RichList< T >( );
			foreach ( T item in items ) {
				list.Add( item );
			}
			return list;
		}
	}
}