using System.Collections.Generic;
using Marina.Presentation;
using Marina.Presentation.DTO;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;
using Marina.Task;
using Marina.Test.Utility;
using Marina.Web;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Presentation {
	[TestFixture]
	public class DockPresenterTest {
		private MockRepository mockery;
		private IDockView mockView;
		private ICatalogTasks mockTask;
		private IHttpRequest mockRequest;

		private IDockPresenter CreateSUT( ) {
			return new DockPresenter( mockView, mockRequest, mockTask );
		}		
		
		[SetUp]
		public void SetUp( ) {
			mockery = new MockRepository( );
			mockView = mockery.DynamicMock< IDockView >( );
			mockTask = mockery.DynamicMock< ICatalogTasks >( );
			mockRequest = mockery.DynamicMock< IHttpRequest >( );
		}

		[Test]
		public void Should_leverage_its_task_to_retrieve_the_dock_information( ) {		
			long dockId = 1;
			using ( mockery.Record( ) ) {
				SetupResult.For( mockRequest.ParsePayloadFor( PayloadKeys.DockId ) ).Return( dockId );
				Expect.Call( mockTask.GetDockInformationBy( dockId ) ).Return( null );
			}
			using ( mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}

		[Test]
		public void Should_display_dock_information( ) {
			DockDisplayDTO dto = ObjectMother.DockDisplayDTO( );
			int dockId = 2;
			
			using ( mockery.Record( ) ) {
				SetupResult.For( mockRequest.ParsePayloadFor( PayloadKeys.DockId ) ).Return( dockId );
				SetupResult.For( mockTask.GetDockInformationBy( dockId ) ).Return( dto );
				mockView.Display( dto );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}

		[Test]
		public void Should_leverage_task_to__load_list_of_locations_on_initialize( ) {
			long dockId = 1;

			using ( mockery.Record( ) ) {
				SetupResult.For( mockRequest.ParsePayloadFor( PayloadKeys.DockId ) ).Return( dockId );
				Expect.Call( mockTask.GetAvailableSlipsForDockBy( dockId ) ).Return( null );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}

		[Test]
		public void Should_display_the_available_slips( ) {
			IEnumerable< SlipDisplayDTO > availableSlips = new List< SlipDisplayDTO >( );
			long dockId = 2;

			using ( mockery.Record( ) ) {
				SetupResult.For( mockRequest.ParsePayloadFor( PayloadKeys.DockId ) ).Return( dockId );
				SetupResult.For( mockTask.GetAvailableSlipsForDockBy( dockId ) ).Return( availableSlips );
				mockView.Display( availableSlips );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}
	}
}