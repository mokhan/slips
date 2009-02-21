using Marina.Infrastructure;
using Marina.Web.Views;

namespace Marina.Web.Commands {
	public class RedirectCommand : ICommand {
		public void Execute() {
			Redirect.To( WebViews.Login );
			//throw new Exception( "Could not find a handler for request" );
		}
	}
}