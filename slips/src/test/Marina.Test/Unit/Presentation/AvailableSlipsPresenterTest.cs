using System.Collections.Generic;
using Marina.Presentation.DTO;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;
using Marina.Task;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Presentation {
	[TestFixture]
	public class AvailableSlipsPresenterTest {
		private MockRepository mockery;
		private ICatalogTasks mockTask;
		private IAvailableSlipsView mockView;

		[SetUp]
		public void SetUp( ) {
			mockery = new MockRepository( );
			mockTask = mockery.DynamicMock< ICatalogTasks >( );
			mockView = mockery.DynamicMock< IAvailableSlipsView >( );
		}

		[Test]
		public void Should_leverage_task_to_retrieve_all_available_slips_on_initialize( ) {
			using ( mockery.Record( ) ) {
				Expect.Call( mockTask.GetAllAvailableSlips( ) ).Return( null );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}

		[Test]
		public void Should_display_the_available_slips( ) {
			IEnumerable< SlipDisplayDTO > availableSlips = new List< SlipDisplayDTO >( );
			using ( mockery.Record( ) ) {
				SetupResult.For( mockTask.GetAllAvailableSlips( ) ).Return( availableSlips );
				mockView.Display( availableSlips );
			}

			using ( mockery.Playback( ) ) {
				CreateSUT( ).Initialize( );
			}
		}

		private IAvailableSlipsPresenter CreateSUT( ) {
			return new AvailableSlipsPresenter( mockView, mockTask );
		}
	}
}