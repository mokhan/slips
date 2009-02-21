using System.Xml;
using log4net.Config;

namespace Marina.Infrastructure.Logging.Log4Net {
	public interface ILog4NetInitializationCommand {
		void Execute( );
	}
}