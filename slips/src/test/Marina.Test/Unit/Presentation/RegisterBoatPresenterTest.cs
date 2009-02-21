using System.Collections.Generic;
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
	public class RegisterBoatPresenterTest {
		private MockRepository mockery;
		private IRegisterBoatView mockView;
		private IRegistrationTasks mockTask;
		private IHttpRequest mockRequest;
		private INewBoatRegistrationMapper mockMapper;

		[SetUp]
		public void SetUp() {
			mockery = new MockRepository( );
			mockView = mockery.DynamicMock< IRegisterBoatView >( );
			mockTask = mockery.DynamicMock< IRegistrationTasks >( );
			mockRequest = mockery.DynamicMock< IHttpRequest >( );
			mockMapper = mockery.DynamicMock< INewBoatRegistrationMapper >( );
		}

		[Test]
		public void Should_leverage_task_to_submit_new_boat_registration() {
			IEnumerable< DisplayResponseLineDTO > response = ObjectMother.EnumerableDisplayResponseLineDTO( );
			BoatRegistrationDTO boat = ObjectMother.BoatRegistrationDTO( );

			using ( mockery.Record( ) ) {
				SetupResult.For( mockMapper.MapFrom( mockRequest ) ).Return( boat );

				Expect.Call( mockTask.AddNewBoatUsing( boat ) ).Return( response );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).SubmitRegistration( );
			}
		}

		[Test]
		public void Should_display_response_from_task_on_view() {
			IEnumerable< DisplayResponseLineDTO > response = ObjectMother.EnumerableDisplayResponseLineDTO( );
			BoatRegistrationDTO boat = ObjectMother.BoatRegistrationDTO( );

			using ( mockery.Record( ) ) {
				SetupResult.For( mockMapper.MapFrom( mockRequest ) ).Return( boat );
				SetupResult.For( mockTask.AddNewBoatUsing( boat ) ).Return( response );

				mockView.Display( response );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).SubmitRegistration( );
			}
		}

		private IRegisterBoatPresenter CreateSUT() {
			return new RegisterBoatPresenter( mockView, mockRequest, mockTask, mockMapper );
		}
	}
}