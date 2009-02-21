using System.Configuration;
using System.Xml;

namespace Marina.Infrastructure.Configuration {
	public class ConfigurationItems {
		public static readonly ConfigurationItem< XmlElement > Log4NetConfigFile = new ConfigurationItem< XmlElement >(
			LoadLog4NetConfig( ) );

		private static XmlElement LoadLog4NetConfig( ) {
			XmlDocument document = new XmlDocument( );
			document.Load( ConfigurationManager.AppSettings[ "LogFileName" ] );
			return document.DocumentElement;
		}
	}
}