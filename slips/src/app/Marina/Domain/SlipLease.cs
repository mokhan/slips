using System;
using Marina.Domain.Interfaces;

namespace Marina.Domain {
	public class SlipLease : ISlipLease {
		public SlipLease( ISlip slip, ILeaseDuration duration )
			: this( slip, duration, DateTime.Now.Date, duration.CalculateExpiryDateFrom( DateTime.Now.Date ) ) {}

		public SlipLease( ISlip slip, ILeaseDuration duration, DateTime startDate, DateTime expiryDate ) {
			_slip = slip;
			_duration = duration;
			_startDate = startDate;
			_expiryDate = expiryDate;
		}

		public ILeaseDuration Duration() {
			return _duration;
		}

		public DateTime StartDate() {
			return _startDate;
		}

		public DateTime ExpiryDate() {
			return _expiryDate;
		}

		public ISlip Slip() {
			return _slip;
		}

		private readonly ILeaseDuration _duration;
		private readonly DateTime _startDate;
		private readonly DateTime _expiryDate;
		private readonly ISlip _slip;
	}
}