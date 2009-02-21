using Marina.Domain.Interfaces;

namespace Marina.Domain {
	internal class BrokenRule : IBrokenRule {
		public BrokenRule( string message ) {
			_message = message;
		}

		public string Message() {
			return _message;
		}

		private readonly string _message;
	}
}