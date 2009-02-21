using Marina.Presentation.DTO;
using Marina.Web;

namespace Marina.Presentation.Mappers {
	public class LeaseRequestDtoFromHttpRequestMapper : ILeaseRequestDtoFromHttpRequestMapper {
		public SubmitLeaseRequestDTO MapFrom( IHttpRequest input ) {
			return new SubmitLeaseRequestDTO(
				input.ParsePayloadFor( PayloadKeys.CustomerId ),
				input.ParsePayloadFor( PayloadKeys.SlipId ),
				input.ParsePayloadFor( PayloadKeys.For( "uxLeaseDuration" ) )
				);
		}
	}
}