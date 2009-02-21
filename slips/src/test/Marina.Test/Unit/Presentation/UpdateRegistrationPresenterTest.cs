using System.Collections.Generic;
using Marina.Presentation;
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
	public class UpdateRegistrationPresenterTest {
		private MockRepository mockery;
		private IRegistrationTasks mockTask;
		private IUpdateRegistrationView mockView;
		private IUpdateRegistrationPresentationMapper mockMapper;
		private IHttpRequest mockRequest;

		[SetUp]
		public void SetUp( ) {
			mockery = new MockRepository( );
			mockView = mockery.DynamicMock< IUpdateRegistrationView >( );
			mockTask = mockery.DynamicMock< IRegistrationTasks >( );
			mockMapper = mockery.DynamicMock< IUpdateRegistrationPresentationMapper >( );
			mockRequest = mockery.DynamicMock< IHttpRequest >( );
		}

		[Test]
		public void Should_leverage_task_to_load_current_registration_information_for_customer( ) {
			int customerId = 1;

			using ( mockery.Record( ) ) {
				SetupResult.For( mockRequest.ParsePayloadFor( PayloadKeys.CustomerId ) ).Return( customerId );
				Expect.Call( mockTask.LoadRegistrationFor( customerId ) ).Return( null );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}

		[Test]
		public void Should_display_the_customer_registration_information_in_the_view( ) {
			int customerId = 1;
			CustomerRegistrationDisplayDTO customerRegistration = ObjectMother.DisplayCustomerRegistrationDTO( );
			using ( mockery.Record( ) ) {
				SetupResult.For( mockRequest.ParsePayloadFor( PayloadKeys.CustomerId ) ).Return( customerId );
				SetupResult.For( mockTask.LoadRegistrationFor( customerId ) ).Return( customerRegistration );
				mockView.Display( customerRegistration );
			}
			using ( mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}

		[Test]
		public void Should_leverage_task_to_submit_changed_registration_information( ) {
			UpdateCustomerRegistrationDTO customer = ObjectMother.UpdateCustomerRegistrationDTO( );

			using ( mockery.Record( ) ) {
				SetupResult.For( mockMapper.MapFrom( mockRequest ) ).Return( customer );
				Expect.Call( mockTask.UpdateRegistrationFor( customer ) ).Return( null );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).UpdateRegistration( );
			}
		}

		[Test]
		public void Should_display_response_on_view( ) {
			IEnumerable< DisplayResponseLineDTO > responseDTO =
				ObjectMother.EnumerableDisplayResponseLineDTO( );

			using ( mockery.Record( ) ) {
				SetupResult.For( mockTask.UpdateRegistrationFor( null ) ).IgnoreArguments( ).Return( responseDTO );
				mockView.Display( responseDTO );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).UpdateRegistration( );
			}
		}

		private IUpdateCustomerRegistrationPresenter CreateSUT( ) {
			return new UpdateCustomerRegistrationPresenter( mockView, mockRequest, mockTask, mockMapper );
		}
	}
}