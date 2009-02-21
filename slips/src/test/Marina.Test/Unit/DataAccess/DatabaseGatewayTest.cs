using System.Data;
using Marina.DataAccess;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.DataAccess {
	[TestFixture]
	public class DatabaseGatewayTest {
		private MockRepository _mockery;
		private IDatabaseConnectionFactory _mockConnectionFactory;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_mockConnectionFactory = _mockery.DynamicMock< IDatabaseConnectionFactory >( );
		}

		public IDatabaseGateway CreateSUT() {
			return new DatabaseGateway( _mockConnectionFactory );
		}

		[Test]
		public void Should_leverage_factory_to_create_a_new_connection() {
			IDatabaseConnection mockConnection = _mockery.DynamicMock< IDatabaseConnection >( );
			using ( _mockery.Record( ) ) {
				Expect.Call( _mockConnectionFactory.Create( ) ).Return( mockConnection );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).LoadTableUsing( "" );
			}
		}

		[Test]
		public void Should_create_command_using_database_connection() {
			IDatabaseConnection mockConnection = _mockery.DynamicMock< IDatabaseConnection >( );
			IDatabaseCommand mockCommand = _mockery.DynamicMock< IDatabaseCommand >( );
			string sqlQuery = "SELECT * FROM ?";

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockConnectionFactory.Create( ) ).Return( mockConnection );
				Expect.Call( mockConnection.CreateCommandFor( sqlQuery ) ).Return( mockCommand );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).LoadTableUsing( sqlQuery );
			}
		}

		[RowTest]
		[Row( "SELECT * FROM Cars" )]
		[Row( "SELECT * FROM Persons" )]
		public void Should_execute_query_on_command( string sqlQuery ) {
			IDatabaseConnection mockConnection = _mockery.DynamicMock< IDatabaseConnection >( );
			IDatabaseCommand mockCommand = _mockery.DynamicMock< IDatabaseCommand >( );

			DataTable table = new DataTable( );
			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockConnectionFactory.Create( ) ).Return( mockConnection );
				SetupResult.For( mockConnection.CreateCommandFor( sqlQuery ) ).Return( mockCommand );
				Expect.Call( mockCommand.ExecuteQuery( ) ).Return( table );
			}

			using ( _mockery.Playback( ) ) {
				Assert.AreEqual( table, CreateSUT( ).LoadTableUsing( sqlQuery ) );
			}
		}

		[Test]
		public void Should_close_the_connection_after_executing_the_command() {
			IDatabaseConnection mockConnection = _mockery.DynamicMock< IDatabaseConnection >( );
			IDatabaseCommand mockCommand = _mockery.DynamicMock< IDatabaseCommand >( );
			string sqlQuery = "SELECT * FROM ?";

			DataTable table = new DataTable( );
			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockConnectionFactory.Create( ) ).Return( mockConnection );
				SetupResult.For( mockConnection.CreateCommandFor( sqlQuery ) ).Return( mockCommand );

				using ( _mockery.Ordered( ) ) {
					Expect.Call( mockCommand.ExecuteQuery( ) ).Return( table );
					mockConnection.Dispose( );
				}
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).LoadTableUsing( sqlQuery );
			}
		}
	}
}