using System.Collections.Generic;
using Marina.Presentation;
using Marina.Presentation.DTO;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;
using Marina.Task;
using Marina.Web;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Presentation {
	[TestFixture]
	public class CurrentLeasesPresenterTest {
		private MockRepository _mockery;
		private ILeaseTasks task;
		private IHttpRequest mockRequest;
		private ICurrentLeasesView mockView;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			task = _mockery.DynamicMock< ILeaseTasks >( );
			mockRequest = _mockery.DynamicMock< IHttpRequest >( );
			mockView = _mockery.DynamicMock< ICurrentLeasesView >( );
		}

		public ICurrentLeasesPresenter CreateSUT() {
			return new CurrentLeasesPresenter( mockView, mockRequest, task );
		}

		[Test]
		public void Should_leverage_task_to_retrieve_all_leases_for_customer_id() {
			long customerId = 32;
			IList< DisplayLeaseDTO > dtos = new List< DisplayLeaseDTO >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( mockRequest.ParsePayloadFor( PayloadKeys.CustomerId ) ).Return( customerId );
				Expect.Call( task.FindAllLeasesFor( customerId ) ).Return( dtos );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}

		[Test]
		public void Should_display_the_found_leases_on_the_view() {
			IList< DisplayLeaseDTO > dtos = new List< DisplayLeaseDTO >( );
			using ( _mockery.Record( ) ) {
				SetupResult
					.For( task.FindAllLeasesFor( 0 ) )
					.IgnoreArguments( )
					.Return( dtos );

				mockView.Display( dtos );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}
	}
}