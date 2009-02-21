using Marina.Infrastructure.Logging.Interfaces;

namespace Marina.Infrastructure.Logging.Log4Net {
	public class Log4NetLog : ILog {
		private log4net.ILog logToAdapt;

		public Log4NetLog( log4net.ILog logToAdapt ) {
			this.logToAdapt = logToAdapt;
		}

		public void Informational( string message ) {
			logToAdapt.Info( message );
		}

		public void Informational( string messageFormat, params object[] args ) {
			logToAdapt.InfoFormat( messageFormat, args );
		}

		public void CriticalError( string messageFormat, params object[] args ) {
			logToAdapt.ErrorFormat( messageFormat, args );
		}
	}
}