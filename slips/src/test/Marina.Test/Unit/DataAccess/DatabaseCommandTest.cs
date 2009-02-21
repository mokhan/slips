using System.Data;
using Marina.DataAccess;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.DataAccess {
	[TestFixture]
	public class DatabaseCommandTest {
		private MockRepository _mockery;
		private IDbCommand _mockCommand;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_mockCommand = _mockery.DynamicMock< IDbCommand >( );
		}

		public IDatabaseCommand CreateSUT() {
			return new DatabaseCommand( _mockCommand );
		}

		[Test]
		public void Should_execute_the_command() {
			IDataReader mockReader = _mockery.DynamicMock< IDataReader >( );

			using ( _mockery.Record( ) ) {
				Expect.Call( _mockCommand.ExecuteReader( ) ).Return( mockReader );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).ExecuteQuery( );
			}
		}

		[Test]
		public void Should_return_a_loaded_data_table() {
			IDataReader mockReader = _mockery.DynamicMock< IDataReader >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockCommand.ExecuteReader( ) ).Return( mockReader );
			}

			using ( _mockery.Playback( ) ) {
				Assert.IsNotNull( CreateSUT( ).ExecuteQuery( ) );
			}
		}
	}
}