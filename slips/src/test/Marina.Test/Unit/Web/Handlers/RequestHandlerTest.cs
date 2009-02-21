using Marina.Infrastructure;
using Marina.Web.Handlers;
using Marina.Web.Http;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Web.Handlers {
	[TestFixture]
	public class RequestHandlerTest {
		private MockRepository _mockery;
		private ISpecification< IHttpGateway > _mockSpecification;
		private ICommand _mockCommand;

		[SetUp]
		public void Setup( ) {
			_mockery = new MockRepository( );
			_mockSpecification = _mockery.DynamicMock< ISpecification< IHttpGateway > >( );
			_mockCommand = _mockery.DynamicMock< ICommand >( );
		}

		[Test]
		public void Should_delegate_to_specification_to_see_if_criteria_is_satisfied( ) {
			IHttpGateway request = _mockery.DynamicMock< IHttpGateway >( );

			using ( _mockery.Record( ) ) {
				Expect.Call( _mockSpecification.IsSatisfiedBy( request ) ).Return( true );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).IsSatisfiedBy( request );
			}
		}

		[Test]
		public void Should_delegate_to_command_when_told_to_execute( ) {
			using ( _mockery.Record( ) ) {
				_mockCommand.Execute( );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Execute( );
			}
		}

		private IRequestHandler CreateSUT( ) {
			return new RequestHandler( _mockSpecification, _mockCommand );
		}
	}
}