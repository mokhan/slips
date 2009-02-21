using Marina.Domain.Interfaces;

namespace Marina.Domain {
	public class DomainObject : IDomainObject {
		private long _id;

		public DomainObject( long id ) {
			_id = id;
		}

		public long ID() {
			return _id;
		}

		void IDomainObject.ChangeIdTo( long id ) {
			_id = id;
		}
	}
}