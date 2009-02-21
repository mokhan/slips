using System;

namespace Marina.Infrastructure.Container {
	public class Resolve {
		private static IDependencyContainer container;

		public static void InitializeWith( IDependencyContainer newContainer
			) {
			container = newContainer;
		}

		public static Interface DependencyFor< Interface >() {
			try {
				return container.GetMeAnImplementationOfAn< Interface >( );
			}
			catch ( Exception e ) {
				throw new InterfaceResolutionException( e, typeof( Interface ) );
			}
		}
	}
}