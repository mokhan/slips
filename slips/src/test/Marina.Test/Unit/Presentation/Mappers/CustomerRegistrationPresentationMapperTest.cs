using Marina.Presentation.DTO;
using Marina.Presentation.Mappers;
using Marina.Presentation.Views;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Presentation.Mappers {
	[TestFixture]
	public class CustomerRegistrationPresentationMapperTest {
		private MockRepository mockery;

		[SetUp]
		public void SetUp( ) {
			mockery = new MockRepository( );
		}

		[Test]
		public void Should_map_view_data_to_dto( ) {
			ICustomerRegistrationView mockView = mockery.DynamicMock< ICustomerRegistrationView >( );
			string userName = "mrMO";
			string password = "password";
			string firstName = "mo";
			string lastName = "khan";
			string phoneNumber = "(403)6813389";
			string city = "calgary";

			using ( mockery.Record( ) ) {
				SetupResult.For( mockView.UserName( ) ).Return( userName );
				SetupResult.For( mockView.Password( ) ).Return( password );
				SetupResult.For( mockView.FirstName( ) ).Return( firstName );
				SetupResult.For( mockView.LastName( ) ).Return( lastName );
				SetupResult.For( mockView.PhoneNumber( ) ).Return( phoneNumber );
				SetupResult.For( mockView.City( ) ).Return( city );
			}

			using ( mockery.Playback( ) ) {
				RegisterCustomerDTO mappedDTO = CreateSUT( ).MapFrom( mockView );

				Assert.AreEqual( mappedDTO.UserName, userName );
				Assert.AreEqual( mappedDTO.Password, password );
				Assert.AreEqual( mappedDTO.FirstName, firstName );
				Assert.AreEqual( mappedDTO.LastName, lastName );
				Assert.AreEqual( mappedDTO.Phone, phoneNumber );
				Assert.AreEqual( mappedDTO.City, city );
			}
		}

		private ICustomerRegistrationPresentationMapper CreateSUT( ) {
			return new CustomerRegistrationPresentationMapper( );
		}
	}
}