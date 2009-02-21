using System.Collections.Generic;
using Marina.Presentation.DTO;
using Marina.Web.Http;
using Marina.Web.Views;
using Marina.Web.Views.Pages;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Web.Views.Pages {
	[TestFixture]
	public class AvailableSlipsWebViewTest {
		private MockRepository _mockery;
		private IViewLuggageTransporter< IEnumerable< SlipDisplayDTO > > _mockViewBag;
		private IHttpGateway _mockGateway;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_mockViewBag = _mockery.DynamicMock< IViewLuggageTransporter< IEnumerable< SlipDisplayDTO > > >( );
			_mockGateway = _mockery.DynamicMock< IHttpGateway >( );
		}

		public IAvailableSlipsWebView CreateSUT() {
			return new AvailableSlipsWebView( _mockViewBag, _mockGateway );
		}

		[Test]
		public void Should_add_item_to_view_bag() {
			IEnumerable< SlipDisplayDTO > slips = new List< SlipDisplayDTO >( );

			using ( _mockery.Record( ) ) {
				_mockViewBag.Add( slips );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).AddToBag( slips );
			}
		}

		[Test]
		public void Should_return_the_name_of_the_page() {
			using ( _mockery.Record( ) ) {}

			using ( _mockery.Playback( ) ) {
				Assert.AreEqual( "AvailableSlips.aspx", CreateSUT( ).Name( ) );
			}
		}
	}
}