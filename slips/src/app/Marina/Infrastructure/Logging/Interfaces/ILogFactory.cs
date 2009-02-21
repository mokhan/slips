using System;

namespace Marina.Infrastructure.Logging.Interfaces {
	public interface ILogFactory {
		ILog CreateFor( Type type );
	}
}