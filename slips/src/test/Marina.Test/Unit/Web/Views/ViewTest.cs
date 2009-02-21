using Marina.Web.Http;
using Marina.Web.Views;
using MbUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace Marina.Test.Unit.Web.Views {
	[TestFixture]
	public class ViewTest {
		private MockRepository _mockery;
		private string _pageName;
		private IHttpGateway _mockGateway;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_mockGateway = _mockery.DynamicMock< IHttpGateway >( );
			_pageName = string.Empty;
		}

		public IView CreateSUT() {
			return new View( _pageName, _mockGateway );
		}

		[Test]
		public void Should_return_the_name_of_the_page_it_was_created_with() {
			_pageName = "TestPage.aspx";

			using ( _mockery.Record( ) ) {}

			using ( _mockery.Playback( ) ) {
				Assert.AreEqual( _pageName, CreateSUT( ).Name( ) );
			}
		}

		[Test]
		public void Should_redirect_to_page() {
			using ( _mockery.Record( ) ) {
				_mockGateway.RedirectTo( null );
				LastCall.Constraints( Is.NotNull( ) );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Render( );
			}
		}
	}
}