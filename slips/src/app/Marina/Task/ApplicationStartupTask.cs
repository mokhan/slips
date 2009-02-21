using Marina.Infrastructure.Container;
using Marina.Infrastructure.Container.Windsor;

namespace Marina.Task {
	public class ApplicationStartupTask : IApplicationStartupTask {
		public static void ApplicationBegin( ) {
			new ApplicationStartupTask( ).Execute( );
		}

		public void Execute( ) {
			Resolve.InitializeWith( new WindsorDependencyContainer( ) );
		}
	}
}