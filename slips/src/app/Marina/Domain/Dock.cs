using Marina.Domain.Interfaces;

namespace Marina.Domain {
	public class Dock : IDock {
		private readonly long _id;
		private readonly string _name;
		private readonly ILocation _location;
		private readonly IUtility _utility;

		public Dock( long id, string name, ILocation location, IUtility utility ) {
			_id = id;
			_name = name;
			_location = location;
			_utility = utility;
		}

		public long ID() {
			return _id;
		}

		public string Name() {
			return _name;
		}

		public ILocation Location() {
			return _location;
		}

		public bool IsUtilityEnabled( IUtility utility ) {
			return _utility.IsEnabled( utility );
		}
	}
}