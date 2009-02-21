using System.Collections.Generic;
using Marina.Presentation.DTO;
using Marina.Presentation.Mappers;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;
using Marina.Task;
using Marina.Test.Utility;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Presentation {
	[TestFixture]
	public class CustomerRegistrationPresenterTest {
		private MockRepository mockery;
		private ICustomerRegistrationPresentationMapper mockMapper;
		private ICustomerRegistrationView mockView;
		private IRegistrationTasks mockTask;

		[SetUp]
		public void SetUp( ) {
			mockery = new MockRepository( );
			mockMapper = mockery.DynamicMock< ICustomerRegistrationPresentationMapper >( );
			mockView = mockery.DynamicMock< ICustomerRegistrationView >( );
			mockTask = mockery.DynamicMock< IRegistrationTasks >( );
		}

		[Test]
		public void Should_leverage_mapper_to_convert_view_data_to_dto( ) {
			using ( mockery.Record( ) ) {
				Expect.Call( mockMapper.MapFrom( mockView ) ).Return( null );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).RegisterCustomer( );
			}
		}

		[Test]
		public void Should_leverage_task_to_submit_new_registration_information( ) {
			RegisterCustomerDTO customerRegistrationDTO = ObjectMother.CustomerRegistrationDTO( );
			using ( mockery.Record( ) ) {
				SetupResult.For( mockMapper.MapFrom( mockView ) ).Return( customerRegistrationDTO );
				Expect.Call( mockTask.RegisterNew( customerRegistrationDTO ) ).Return( null );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).RegisterCustomer( );
			}
		}

		[Test]
		public void Should_display_response_on_view( ) {
			IEnumerable< DisplayResponseLineDTO > responseDTO =
				ObjectMother.EnumerableDisplayResponseLineDTO( );
			using ( mockery.Record( ) ) {
				SetupResult.For( mockTask.RegisterNew( null ) ).IgnoreArguments( ).Return( responseDTO );
				mockView.Display( responseDTO );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).RegisterCustomer( );
			}
		}

		private ICustomerRegistrationPresenter CreateSUT( ) {
			return new CustomerRegistrationPresenter( mockView, mockMapper, mockTask );
		}
	}
}