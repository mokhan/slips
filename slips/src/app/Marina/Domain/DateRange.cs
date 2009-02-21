using System;
using Marina.Domain.Interfaces;

namespace Marina.Domain {
	internal class DateRange : IDateRange {
		public DateRange( DateTime startDate, DateTime endDate ) {
			_startDate = startDate;
			_endDate = endDate;
		}

		public DateTime Start() {
			return _startDate;
		}

		public DateTime End() {
			return _endDate;
		}

		private readonly DateTime _startDate;
		private readonly DateTime _endDate;
	}
}