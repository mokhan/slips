using Marina.Presentation.DTO;
using Marina.Web;

namespace Marina.Presentation.Mappers {
	public class NewBoatRegistrationMapper : INewBoatRegistrationMapper {
		public BoatRegistrationDTO MapFrom( IHttpRequest input ) {
			return new BoatRegistrationDTO(
				input.ParsePayloadFor( PayloadKeys.For( "uxRegistrationNumberTextBox" ) ),
				input.ParsePayloadFor( PayloadKeys.For( "uxManufacturerTextBox" ) ),
				input.ParsePayloadFor( PayloadKeys.For( "uxModelYearTextBox" ) ),
				input.ParsePayloadFor( PayloadKeys.For( "uxLengthTextBox" ) ),
				input.ParsePayloadFor( PayloadKeys.CustomerId )
				);
		}
	}
}