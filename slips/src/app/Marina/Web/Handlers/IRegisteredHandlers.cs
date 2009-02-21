using System.Collections.Generic;
using Marina.Web.Handlers;

namespace Marina.Web.Handlers {
	public interface IRegisteredHandlers {
		IEnumerable< IRequestHandler > All( );
	}
}