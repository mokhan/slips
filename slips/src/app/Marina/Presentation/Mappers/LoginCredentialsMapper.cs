using Marina.Presentation.DTO;
using Marina.Web;

namespace Marina.Presentation.Mappers {
	public class LoginCredentialsMapper : ILoginCredentialsMapper {
		public LoginCredentialsDTO MapFrom( IHttpRequest input ) {
			return new LoginCredentialsDTO(
				input.ParsePayloadFor( PayloadKeys.For( "uxUserNameTextBox" ) ),
				input.ParsePayloadFor( PayloadKeys.For( "uxPasswordTextBox" ) )
				);
		}
	}
}