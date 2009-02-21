using Marina.Infrastructure.Container;
using Marina.Infrastructure.Logging.Interfaces;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Infrastructure.Logging.Interfaces {
	[TestFixture]
	public class LogTest {
		private MockRepository mockery;

		[SetUp]
		public void SetUp( ) {
			mockery = new MockRepository( );
		}

		[Test]
		public void Should_leverage_factory_to_return_a_logger_to_the_client( ) {
			ILog mockLog = mockery.DynamicMock< ILog >( );
			ILogFactory mockLogFactory = mockery.DynamicMock< ILogFactory >( );

			IDependencyContainer mockContainer = mockery.DynamicMock< IDependencyContainer >( );

			using ( mockery.Record( ) ) {
				Expect.Call( mockContainer.GetMeAnImplementationOfAn< ILogFactory >( ) ).Return( mockLogFactory );
				Expect.Call( mockLogFactory.CreateFor( typeof( LogTest ) ) ).Return( mockLog );
			}

			using ( mockery.Playback( ) ) {
				Resolve.InitializeWith( mockContainer );
				ILog log = Log.For( this );
				Assert.AreEqual( mockLog, log );
				Resolve.InitializeWith( null );
			}
		}
	}
}