using System.Xml;
using log4net.Config;
using Marina.Infrastructure.Configuration;

namespace Marina.Infrastructure.Logging.Log4Net {
	public class Log4NetInitializationCommand : ILog4NetInitializationCommand {
		private readonly XmlElement configuration;

		public Log4NetInitializationCommand( ) : this( ConfigurationItems.Log4NetConfigFile.Value( ) ) {}

		public Log4NetInitializationCommand( XmlElement configuration ) {
			this.configuration = configuration;
		}

		public void Execute( ) {
			XmlConfigurator.Configure( configuration );
		}
	}
}