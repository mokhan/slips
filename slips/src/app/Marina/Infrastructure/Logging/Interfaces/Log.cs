using System;
using Marina.Infrastructure.Container;

namespace Marina.Infrastructure.Logging.Interfaces {
	public class Log {
		public static ILog For( object itemThatRequiresLoggingServices ) {
			return For( itemThatRequiresLoggingServices.GetType( ) );
		}

		public static ILog For( Type type ) {
			return Resolve.DependencyFor< ILogFactory >( ).CreateFor( type );
		}
	}
}