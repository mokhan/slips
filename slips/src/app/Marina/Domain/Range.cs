using System;
using Marina.Domain.Interfaces;

namespace Marina.Domain {
	public class Range< T > : IRange< T > where T : IComparable< T > {
		private readonly T start;
		private readonly T end;

		public Range( T start, T end ) {
			if ( start.CompareTo( end ) <= 0 ) {
				this.start = start;
				this.end = end;
			}
			else {
				this.start = end;
				this.end = start;
			}
		}

		public T Start() {
			return start;
		}

		public T End() {
			return end;
		}

		public bool Contains( T value ) {
			return value.CompareTo( start ) >= 0 && value.CompareTo( end ) <= 0;
		}
	}
}