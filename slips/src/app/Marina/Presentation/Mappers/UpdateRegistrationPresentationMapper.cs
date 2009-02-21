using Marina.Presentation.DTO;
using Marina.Web;

namespace Marina.Presentation.Mappers {
	public class UpdateRegistrationPresentationMapper : IUpdateRegistrationPresentationMapper {
		public UpdateCustomerRegistrationDTO MapFrom( IHttpRequest input ) {
			return new UpdateCustomerRegistrationDTO(
				input.ParsePayloadFor( PayloadKeys.CustomerId ),
				input.ParsePayloadFor( PayloadKeys.For( "uxUserNameTextBox" ) ),
				input.ParsePayloadFor( PayloadKeys.For( "uxPasswordTextBox" ) ),
				input.ParsePayloadFor( PayloadKeys.For( "uxFirstNameTextBox" ) ),
				input.ParsePayloadFor( PayloadKeys.For( "uxLastNameTextBox" ) ),
				input.ParsePayloadFor( PayloadKeys.For( "uxPhoneNumberTextBox" ) ),
				input.ParsePayloadFor( PayloadKeys.For( "uxCityTextBox" ) )
				);
		}
	}
}