using Marina.Presentation;
using Marina.Presentation.DTO;
using Marina.Presentation.Mappers;
using Marina.Web;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Presentation.Mappers {
	[TestFixture]
	public class UpdateRegistrationPresentationMapperTest {
		private MockRepository mockery;
		private IHttpRequest mockRequest;

		[SetUp]
		public void SetUp( ) {
			mockery = new MockRepository( );
			mockRequest = mockery.DynamicMock< IHttpRequest >( );
		}

		[RowTest]
		[Row( 0, "username", "password", "mo", "khan", "4036813389", "calgary" )]
		[Row( 0, "username1", "p@ssword", "m0", "khAAn", "d33d9", "toronto" )]
		[Row( 0, "username2", "passw0rd", "m1", "kh@n", "4036d333389", "new york" )]
		public void Should_map_the_data_from_the_view_to_the_dto( long customerId, string userName, string password,
		                                                          string firstName,
		                                                          string lastName, string phone, string city ) {
			using ( mockery.Record( ) ) {
				SetupResult.For( mockRequest.ParsePayloadFor( PayloadKeys.CustomerId ) ).Return( customerId );
				SetupResult.For( mockRequest.ParsePayloadFor( Create( "uxUserNameTextBox" ) ) ).Return( userName );
				SetupResult.For( mockRequest.ParsePayloadFor( Create( "uxPasswordTextBox" ) ) ).Return( password );
				SetupResult.For( mockRequest.ParsePayloadFor( Create( "uxFirstNameTextBox" ) ) ).Return( firstName );
				SetupResult.For( mockRequest.ParsePayloadFor( Create( "uxLastNameTextBox" ) ) ).Return( lastName );
				SetupResult.For( mockRequest.ParsePayloadFor( Create( "uxPhoneNumberTextBox" ) ) ).Return( phone );
				SetupResult.For( mockRequest.ParsePayloadFor( Create( "uxCityTextBox" ) ) ).Return( city );
			}

			using ( mockery.Playback( ) ) {
				UpdateCustomerRegistrationDTO dto = CreateSUT( ).MapFrom( mockRequest );
				Assert.AreEqual( customerId, dto.CustomerId );
				Assert.AreEqual( userName, dto.Username );
				Assert.AreEqual( password, dto.Password );
				Assert.AreEqual( firstName, dto.FirstName );
				Assert.AreEqual( lastName, dto.LastName );
				Assert.AreEqual( phone, dto.PhoneNumber );
				Assert.AreEqual( city, dto.City );
			}
		}

		public PayloadKey< string > Create( string controlId ) {
			return PayloadKeys.For( controlId );
		}

		private IUpdateRegistrationPresentationMapper CreateSUT( ) {
			return new UpdateRegistrationPresentationMapper( );
		}
	}
}