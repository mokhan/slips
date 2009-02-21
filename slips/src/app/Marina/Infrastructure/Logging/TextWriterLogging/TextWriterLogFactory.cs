using System;
using Marina.Infrastructure.Logging.Interfaces;

namespace Marina.Infrastructure.Logging.TextWriterLogging {
	public class TextWriterLogFactory : ILogFactory {
		public ILog CreateFor( Type type ) {
			return new TextWriterLog( Console.Out );
		}
	}
}