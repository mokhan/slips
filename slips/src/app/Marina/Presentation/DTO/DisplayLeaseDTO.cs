using System;

namespace Marina.Presentation.DTO {
	[Serializable]
	public class DisplayLeaseDTO {
		public DisplayLeaseDTO( string slipID, string startDate, string expiryDate ) {
			_slipID = slipID;
			_startDate = startDate;
			_expiryDate = expiryDate;
		}

		public string SlipID {
			get { return _slipID; }
		}

		public string StartDate {
			get { return _startDate; }
		}

		public string ExpiryDate {
			get { return _expiryDate; }
		}

		private string _slipID;
		private string _startDate;
		private string _expiryDate;
	}
}