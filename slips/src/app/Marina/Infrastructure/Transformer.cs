using System;

namespace Marina.Infrastructure {
	public class Transformer : ITransformer {
		private object item;

		public Transformer( object item ) {
			this.item = item;
		}

		public Result To< Result >( ) {
			EnsureItemIsNotNull( );
			return ( Result )item;
		}

		private void EnsureItemIsNotNull( ) {
			if ( item == null ) {
				throw new NullReferenceException( );
			}
		}
	}
}