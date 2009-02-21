using System;
using log4net;
using Marina.Infrastructure.Logging.Interfaces;
using ILog=Marina.Infrastructure.Logging.Interfaces.ILog;

namespace Marina.Infrastructure.Logging.Log4Net {
	public class Log4NetLogFactory : ILogFactory {
		private ILog4NetInitializationCommand initializationCommand;
		private bool initialized;

		public Log4NetLogFactory( ) : this( new Log4NetInitializationCommand( ) ) {}

		public Log4NetLogFactory( ILog4NetInitializationCommand initializationCommand ) {
			this.initializationCommand = initializationCommand;
		}

		public ILog CreateFor( Type typeThatRequiresLoggingServices ) {
			WireUpConfiguration( );
			return new Log4NetLog( LogManager.GetLogger( typeThatRequiresLoggingServices ) );
		}

		private void WireUpConfiguration( ) {
			if ( initialized ) {
				return;
			}
			initialized = true;
			initializationCommand.Execute( );
		}
	}
}