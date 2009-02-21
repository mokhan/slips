using System;

namespace Marina.Presentation.DTO {
	[Serializable]
	public class SlipDisplayDTO {
		private SlipDisplayDTO() {}

		public SlipDisplayDTO( string dockId, string dockName, string width, string length, string locationName, string slipId ) {
			_dockName = dockName;
			_slipId = slipId;
			_locationName = locationName;
			_dockId = dockId;
			_width = width;
			_length = length;
		}

		public string DockName {
			get { return _dockName; }
		}

		public string Width {
			get { return _width; }
		}

		public string Length {
			get { return _length; }
		}

		public string DockId {
			get { return _dockId; }
		}

		public string LocationName {
			get { return _locationName; }
		}

		public string SlipId {
			get { return _slipId; }
		}

		private string _dockName;
		private string _width;
		private string _length;
		private string _dockId;
		private string _locationName;
		private string _slipId;
	}
}