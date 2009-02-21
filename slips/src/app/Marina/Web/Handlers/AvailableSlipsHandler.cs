using Marina.Web.Commands;

namespace Marina.Web.Handlers {
	public class AvailableSlipsHandler : RequestHandler {
		public AvailableSlipsHandler() : base( For( CommandNames.AvailableSlips ), new AvailableSlipsCommand( ) ) {}
	}
}