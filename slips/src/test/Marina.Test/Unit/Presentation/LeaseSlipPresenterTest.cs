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
	public class LeaseSlipPresenterTest {
		private MockRepository _mockery;
		private IHttpRequest _mockRequest;
		private ICatalogTasks _mockTask;
		private ILeaseSlipView _mockView;
		private ILeaseTasks _mockLeaseTasks;
		private ILeaseRequestDtoFromHttpRequestMapper _mockMapper;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_mockRequest = _mockery.DynamicMock< IHttpRequest >( );
			_mockTask = _mockery.DynamicMock< ICatalogTasks >( );
			_mockLeaseTasks = _mockery.DynamicMock< ILeaseTasks >( );
			_mockView = _mockery.DynamicMock< ILeaseSlipView >( );

			_mockMapper = _mockery.DynamicMock< ILeaseRequestDtoFromHttpRequestMapper >( );
		}

		public ILeaseSlipPresenter CreateSUT() {
			return new LeaseSlipPresenter( _mockView, _mockRequest, _mockTask, _mockLeaseTasks, _mockMapper );
		}

		[Test]
		public void Should_leverage_task_to_retrieve_information_on_slip() {
			long slipId = 66;
			SlipDisplayDTO slip = ObjectMother.SlipDisplayDTO( );
			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockRequest.ParsePayloadFor( PayloadKeys.SlipId ) ).Return( slipId );
				Expect.Call( _mockTask.FindSlipBy( slipId ) ).Return( slip );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}

		[Test]
		public void Should_display_found_slip_on_view() {
			SlipDisplayDTO slip = ObjectMother.SlipDisplayDTO( );
			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockTask.FindSlipBy( 0 ) ).IgnoreArguments( ).Return( slip );
				_mockView.Display( slip );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}

		[Test]
		public void Should_save_lease_slip_when_customer_submits_a_request() {
			long customerId = 2;
			long slipId = 3;

			SubmitLeaseRequestDTO request = new SubmitLeaseRequestDTO( customerId, slipId, "weekly" );
			DisplayResponseLineDTO response = new DisplayResponseLineDTO( "" );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockMapper.MapFrom( _mockRequest ) ).Return( request );
				Expect.Call( _mockLeaseTasks.RequestLeaseUsing( request ) ).Return( response );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).SubmitLeaseRequest( );
			}
		}

		[Test]
		public void Should_display_response_from_lease_request_on_the_view() {
			SubmitLeaseRequestDTO request = new SubmitLeaseRequestDTO( 1, 1, "weekly" );
			DisplayResponseLineDTO response = new DisplayResponseLineDTO( "" );

			using ( _mockery.Record( ) ) {
				SetupResult
					.For( _mockLeaseTasks.RequestLeaseUsing( request ) )
					.IgnoreArguments( )
					.Return( response );
				_mockView.Display( response );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).SubmitLeaseRequest( );
			}
		}
	}
}