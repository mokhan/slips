using System;
using System.Collections.Generic;

namespace Marina.Infrastructure {
	public class RichList< T > : List< T >, IRichList< T > {
		public RichList( IEnumerable< T > collection )
			: base( collection ) {}

		public RichList( int capacity )
			: base( capacity ) {}

		public RichList() {}

		public IEnumerable< Output > MapAllUsing< Output >( IMapper< T, Output > mapper ) {
			return ConvertAll< Output >( mapper.MapFrom );
		}

		public IEnumerable< T > All() {
			foreach ( T t in this ) {
				yield return t;
			}
		}

		public new IRichList< TOutput > ConvertAll< TOutput >( Converter< T, TOutput > converter ) {
			return new RichList< TOutput >( base.ConvertAll( converter ) );
		}

		public new IRichList< T > FindAll( Predicate< T > match ) {
			return new RichList< T >( base.FindAll( match ) );
		}

		public new IRichList< T > GetRange( int index, int count ) {
			return new RichList< T >( base.GetRange( index, count ) );
		}

		public void VisitAllItemWith( IVisitor< T > visitor ) {
			ForEach( visitor.Visit );
		}

		public Result GetResultOfVisitingAllItemsWith< Result >( IValueReturningVisitor< Result, T > visitor ) {
			VisitAllItemWith( visitor );
			return visitor.GetResult( );
		}
	}
}