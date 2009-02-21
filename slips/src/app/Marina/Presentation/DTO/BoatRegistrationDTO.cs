using System;

namespace Marina.Presentation.DTO {
	[Serializable]
	public class BoatRegistrationDTO {
		private readonly string registrationNumber;
		private readonly string manufacturer;
		private readonly string modelYear;
		private readonly string length;
		private readonly long customerId;

		public BoatRegistrationDTO( string registrationNumber, string manufacturer, string modelYear, string length,
		                            long customerId ) {
			this.registrationNumber = registrationNumber;
			this.manufacturer = manufacturer;
			this.modelYear = modelYear;
			this.length = length;
			this.customerId = customerId;
		}

		public string RegistrationNumber {
			get { return registrationNumber; }
		}

		public string Manufacturer {
			get { return manufacturer; }
		}

		public string ModelYear {
			get { return modelYear; }
		}

		public string Length {
			get { return length; }
		}

		public long CustomerId {
			get { return customerId; }
		}
	}
}