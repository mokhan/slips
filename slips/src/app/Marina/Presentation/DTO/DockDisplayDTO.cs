using System;

namespace Marina.Presentation.DTO {
	[Serializable]
	public class DockDisplayDTO {
		private readonly string _name;
		private readonly string _locationName;
		private readonly string _waterService;
		private readonly string _electricalService;

		private DockDisplayDTO() {}

		public DockDisplayDTO( string name, string locationName, string waterService, string electricalService ) {
			_name = name;
			_locationName = locationName;
			_waterService = waterService;
			_electricalService = electricalService;
		}

		public string Name {
			get { return _name; }
		}

		public string LocationName {
			get { return _locationName; }
		}

		public string WaterService {
			get { return _waterService; }
		}

		public string ElectricalService {
			get { return _electricalService; }
		}
	}
}