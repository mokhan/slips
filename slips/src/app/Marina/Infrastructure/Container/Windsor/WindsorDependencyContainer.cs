using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace Marina.Infrastructure.Container.Windsor {
	public class WindsorDependencyContainer : IDependencyContainer {
		private readonly IWindsorContainer _container;

		public WindsorDependencyContainer() {
			_container = new WindsorContainer( new XmlInterpreter( @"windsor.config.xml" ) );
		}

		public Interface GetMeAnImplementationOfAn< Interface >() {
			return _container.Resolve< Interface >( );
		}
	}
}