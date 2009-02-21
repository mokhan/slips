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
	public class ViewRegisteredBoatsPresenterTest {
		private MockRepository _mockery;
		private IRegistrationTasks _mockTask;
		private IHttpRequest _mockRequest;
		private IRegisteredBoatsView _mockView;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_mockTask = _mockery.DynamicMock< IRegistrationTasks >( );
			_mockRequest = _mockery.DynamicMock< IHttpRequest >( );
			_mockView = _mockery.DynamicMock< IRegisteredBoatsView >( );
		}

		public IViewRegisteredBoatsPresenter CreateSUT() {
			return new ViewRegisteredBoatsPresenter( _mockView, _mockTask, _mockRequest );
		}

		[Test]
		public void Should_leverage_task_to_retrieve_all_registered_boats_for_customer() {
			long customerId = 23;
			IList< BoatRegistrationDTO > boats = new List< BoatRegistrationDTO >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockRequest.ParsePayloadFor( PayloadKeys.CustomerId ) ).Return( customerId );
				Expect.Call( _mockTask.AllBoatsFor( customerId ) ).Return( boats );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}

		[Test]
		public void Should_display_registered_boats_on_view() {
			IList< BoatRegistrationDTO > boats = new List< BoatRegistrationDTO >( );
			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockTask.AllBoatsFor( 0 ) )
					.IgnoreArguments( )
					.Return( boats );

				_mockView.Display( boats );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}
	}
}