using System.IO;
using Marina.Infrastructure.Logging.Interfaces;

namespace Marina.Infrastructure.Logging.TextWriterLogging {
	public class TextWriterLog : ILog {
		private readonly TextWriter _writer;

		public TextWriterLog( TextWriter writer ) {
			_writer = writer;
		}

		public void Informational( string message ) {
			_writer.WriteLine( message );
		}

		public void Informational( string messageFormat, params object[] args ) {
			_writer.WriteLine( messageFormat, args );
		}

		public void CriticalError( string messageFormat, params object[] args ) {
			Informational( messageFormat, args );
		}
	}
}