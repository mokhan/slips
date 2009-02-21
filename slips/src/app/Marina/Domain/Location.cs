using Marina.Domain.Interfaces;

namespace Marina.Domain {
	public class Location : ILocation {
		public Location( string name ) {
			_name = name;
		}

		public string Name() {
			return _name;
		}

		private readonly string _name;
	}
}