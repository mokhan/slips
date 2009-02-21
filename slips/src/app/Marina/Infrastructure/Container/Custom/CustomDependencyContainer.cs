using System;
using System.Collections.Generic;

namespace Marina.Infrastructure.Container.Custom {
	public class CustomDependencyContainer : IDependencyContainer {
		private static IDictionary< Type, object > list;

		public CustomDependencyContainer( ) {
			list = new Dictionary< Type, object >( );
		}

		public Interface GetMeAnImplementationOfAn< Interface >( ) {
			Type currentType = typeof( Interface );
			return ( Interface )list[ currentType ];
		}

		public void AddImplementationOf< Interface >( Interface objectToRegister ) {
			list.Add( typeof( Interface ), objectToRegister );
		}
	}
}