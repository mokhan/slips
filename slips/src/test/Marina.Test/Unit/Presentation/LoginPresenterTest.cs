using Marina.Presentation.DTO;
using Marina.Presentation.Mappers;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;
using Marina.Task;
using Marina.Test.Utility;
using Marina.Web;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Presentation {
	[TestFixture]
	public class LoginPresenterTest {
		private MockRepository mockery;
		private ILoginView mockView;
		private IAuthenticationTask mockTask;
		private ILoginCredentialsMapper mockMapper;
		private IHttpRequest mockRequest;

		[SetUp]
		public void SetUp() {
			mockery = new MockRepository( );
			mockView = mockery.DynamicMock< ILoginView >( );
			mockTask = mockery.DynamicMock< IAuthenticationTask >( );
			mockRequest = mockery.DynamicMock< IHttpRequest >( );
			mockMapper = mockery.DynamicMock< ILoginCredentialsMapper >( );
		}

		[Test]
		public void Should_leverage_task_to_check_if_credentials_are_correct() {
			LoginCredentialsDTO credentials = ObjectMother.LoginCredentialsDTO( );
			using ( mockery.Record( ) ) {
				SetupResult.For( mockMapper.MapFrom( mockRequest ) ).Return( credentials );
				Expect.Call( mockTask.AuthenticateUserUsing( credentials ) ).Return( null );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).Login( );
			}
		}

		[Test]
		public void Should_display_response_messages_from_task() {
			DisplayResponseLineDTO responseMessage = ObjectMother.DisplayResponseLineDTO( );
			using ( mockery.Record( ) ) {
				SetupResult
					.For( mockTask.AuthenticateUserUsing( null ) )
					.IgnoreArguments( )
					.Return( responseMessage );
				mockView.Display( responseMessage );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).Login( );
			}
		}

		private ILoginPresenter CreateSUT() {
			return new LoginPresenter( mockView, mockRequest, mockTask, mockMapper );
		}
	}
}