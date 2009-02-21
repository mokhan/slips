using Marina.Infrastructure;
using Marina.Web.Handlers;
using Marina.Web.Http;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Web.Handlers {
	[TestFixture]
	public class RequestHandlerSpecificationTest {
		private MockRepository _mockery;

		[SetUp]
		public void Setup( ) {
			_mockery = new MockRepository( );
		}

		[TearDown]
		public void TearDown( ) {
			_mockery.VerifyAll( );
		}

		[Test]
		public void Should_return_true_if_destination_contains_command_name( ) {
			IHttpGateway mockRequest = _mockery.DynamicMock< IHttpGateway >( );
			string commandName = "test.marina";
			using ( _mockery.Record( ) ) {
				SetupResult.For( mockRequest.Destination( ) ).Return( commandName );
			}

			using ( _mockery.Playback( ) ) {
				Assert.IsTrue( CreateSUT( commandName ).IsSatisfiedBy( mockRequest ) );
			}
		}

		[Test]
		public void Should_return_false_if_destination_does_not_contain_command_name( ) {
			IHttpGateway mockRequest = _mockery.DynamicMock< IHttpGateway >( );
			string firstCommandName = "test.marina";
			string secondCommandName = "test2.marina";

			using ( _mockery.Record( ) ) {
				SetupResult.For( mockRequest.Destination( ) ).Return( secondCommandName );
			}
			using ( _mockery.Playback( ) ) {
				Assert.IsFalse( CreateSUT( firstCommandName ).IsSatisfiedBy( mockRequest ) );
			}
		}

		private ISpecification< IHttpGateway > CreateSUT( string commandName ) {
			return new RequestHandlerSpecification( commandName );
		}
	}
}