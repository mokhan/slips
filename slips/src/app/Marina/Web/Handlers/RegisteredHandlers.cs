using System.Collections.Generic;

namespace Marina.Web.Handlers {
	public class RegisteredHandlers : IRegisteredHandlers {
		public IEnumerable< IRequestHandler > All() {
			yield return new AvailableSlipsHandler( );
		}
	}
}