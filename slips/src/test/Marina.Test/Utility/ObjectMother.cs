using System;
using System.Collections.Generic;
using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Presentation.DTO;

namespace Marina.Test.Utility {
	public class ObjectMother {
		public static RegisterCustomerDTO CustomerRegistrationDTO() {
			return
				new RegisterCustomerDTO( string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty );
		}

		public static IEnumerable< DisplayResponseLineDTO > EnumerableDisplayResponseLineDTO() {
			return new List< DisplayResponseLineDTO >( );
		}

		public static DockDisplayDTO DockDisplayDTO() {
			return new DockDisplayDTO( string.Empty, string.Empty, string.Empty, string.Empty );
		}

		public static CustomerRegistrationDisplayDTO DisplayCustomerRegistrationDTO() {
			return
				new CustomerRegistrationDisplayDTO( string.Empty, string.Empty, string.Empty, string.Empty,
				                                    string.Empty, string.Empty );
		}

		public static UpdateCustomerRegistrationDTO UpdateCustomerRegistrationDTO() {
			return new UpdateCustomerRegistrationDTO( 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
			                                          string.Empty );
		}

		public static BoatRegistrationDTO BoatRegistrationDTO() {
			return new BoatRegistrationDTO( string.Empty, string.Empty, string.Empty, string.Empty, 0 );
		}

		public static LoginCredentialsDTO LoginCredentialsDTO() {
			return new LoginCredentialsDTO( string.Empty, string.Empty );
		}

		public static SlipDisplayDTO SlipDisplayDTO() {
			return new SlipDisplayDTO( "1", "dock a", "100", "100", "location a", "2" );
		}

		public static ILocation Location() {
			return new Location( "location a" );
		}

		public static IBoat Boat() {
			return new Boat( -1, string.Empty, string.Empty, DateTime.Now, 100 );
		}

		public static ISlip Slip() {
			return new Slip( -1, null, 100, 100, false );
		}

		public static ICustomer Customer() {
			return new Customer( );
		}

		public static IDock Dock() {
			return new Dock( -1, "dock a", null, null );
		}

		public static DisplayResponseLineDTO DisplayResponseLineDTO() {
			return new DisplayResponseLineDTO( string.Empty );
		}
	}
}