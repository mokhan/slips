namespace Marina.Infrastructure.Logging.Interfaces {
	public interface ILog {
		void Informational( string message );
		void Informational( string messageFormat, params object[] args );
		void CriticalError( string messageFormat, params object[] args );
	}
}