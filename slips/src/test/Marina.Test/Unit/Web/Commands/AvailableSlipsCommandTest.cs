using System.Collections.Generic;
using Marina.Infrastructure;
using Marina.Presentation.DTO;
using Marina.Task;
using Marina.Web.Commands;
using Marina.Web.Views.Pages;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Web.Commands {
	[TestFixture]
	public class AvailableSlipsCommandTest {
		private MockRepository _mockery;
		private ICatalogTasks _mockTask;
		private IAvailableSlipsWebView _mockView;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_mockTask = _mockery.DynamicMock< ICatalogTasks >( );
			_mockView = _mockery.DynamicMock< IAvailableSlipsWebView >( );
		}

		private ICommand CreateSUT() {
			return new AvailableSlipsCommand( _mockView, _mockTask );
		}

		[Test]
		public void Should_leverage_task_to_retrieve_all_available_slips_on_initialize() {
			using ( _mockery.Record( ) ) {
				Expect.Call( _mockTask.GetAllAvailableSlips( ) ).Return( null );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Execute( );
			}
		}

		[Test]
		public void Should_add_available_slips_to_bag_and_render_view() {
			IEnumerable< SlipDisplayDTO > slips = new List< SlipDisplayDTO >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockTask.GetAllAvailableSlips( ) ).Return( slips );
				using ( _mockery.Ordered( ) ) {
					_mockView.AddToBag( slips );
					_mockView.Render( );
				}
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Execute( );
			}
		}
	}
}