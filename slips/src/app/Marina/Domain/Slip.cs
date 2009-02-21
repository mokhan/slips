using Marina.Domain.Exceptions;
using Marina.Domain.Interfaces;

namespace Marina.Domain {
	public class Slip : DomainObject, ISlip {
		public Slip( long id, IDock dock, int width, int length, bool isLeased ) : base( id ) {
			_dock = dock;
			_width = width;
			_length = length;
			_isLeased = isLeased;
		}

		public IDock Dock() {
			return _dock;
		}

		public ILocation Location() {
			return _dock.Location( );
		}

		public int Width() {
			return _width;
		}

		public int Length() {
			return _length;
		}

		public ISlipLease LeaseTo( ICustomer customer, ILeaseDuration duration ) {
			if ( !IsLeased( ) ) {
				_isLeased = true;
				return new SlipLease( this, duration );
			}
			throw new SlipIsAlreadyLeasedException( );
		}

		public bool IsLeased() {
			return _isLeased;
		}

		private readonly IDock _dock;
		private readonly int _width;
		private readonly int _length;
		private bool _isLeased;
	}
}