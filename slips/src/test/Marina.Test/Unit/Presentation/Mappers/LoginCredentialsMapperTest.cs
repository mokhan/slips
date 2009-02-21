using Marina.Presentation;
using Marina.Presentation.Mappers;
using Marina.Web;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Presentation.Mappers {
	[TestFixture]
	public class LoginCredentialsMapperTest {
		private MockRepository mockery;
		private IHttpRequest mockRequest;

		[SetUp]
		public void SetUp( ) {
			mockery = new MockRepository( );
			mockRequest = mockery.DynamicMock< IHttpRequest >( );
		}

		[Test]
		public void Should_map_username_from_request( ) {
			using ( mockery.Record( ) ) {
				Expect.Call( mockRequest.ParsePayloadFor( PayloadKeys.For( "uxUserNameTextBox" ) ) ).Return( null );
				Expect.Call( mockRequest.ParsePayloadFor( PayloadKeys.For( "uxPasswordTextBox" ) ) ).Return( null );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).MapFrom( mockRequest );
			}
		}

		private LoginCredentialsMapper CreateSUT( ) {
			return new LoginCredentialsMapper( );
		}
	}
}