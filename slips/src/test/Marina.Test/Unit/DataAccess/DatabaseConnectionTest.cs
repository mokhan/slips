using System.Data;
using Marina.DataAccess;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.DataAccess {
	[TestFixture]
	public class DatabaseConnectionTest {
		private MockRepository _mockery;
		private IDatabaseConfiguration _mockConfiguration;
		private IDatabaseProviderFactory _mockProviderFactory;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_mockConfiguration = _mockery.DynamicMock< IDatabaseConfiguration >( );
			_mockProviderFactory = _mockery.DynamicMock< IDatabaseProviderFactory >( );
		}

		public IDatabaseConnection CreateSUT() {
			return new DatabaseConnection( _mockConfiguration, _mockProviderFactory );
		}

		[Test]
		public void Should_create_connection_for_provider_name() {
			string providerName = "System.Data.SqlClient";

			IDbConnection mockConnection = _mockery.DynamicMock< IDbConnection >( );
			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockConfiguration.ProviderName( ) ).Return( providerName );

				Expect.Call( _mockProviderFactory.CreateConnectionFor( providerName ) ).Return( mockConnection );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).CreateCommandFor( "" );
			}
		}

		[RowTest]
		[Row( "MyConnectionString" )]
		[Row( "MyStringOfConnection" )]
		[Row( "MyConnectionString3" )]
		public void Should_set_the_connections_connection_string_to( string connectionString ) {
			string providerName = "System.Data.SqlClient";

			IDbConnection mockConnection = _mockery.DynamicMock< IDbConnection >( );
			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockConfiguration.ConnectionString( ) ).Return( connectionString );
				SetupResult.For( _mockConfiguration.ProviderName( ) ).Return( providerName );
				SetupResult.For( _mockProviderFactory.CreateConnectionFor( providerName ) ).Return( mockConnection );

				mockConnection.ConnectionString = connectionString;
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).CreateCommandFor( "" );
			}
		}

		[Test]
		public void Should_create_a_command_object_using_the_connection() {
			string providerName = "System.Data.SqlClient";
			string connectionString = "MyConnectionString";

			IDbConnection mockConnection = _mockery.DynamicMock< IDbConnection >( );
			IDbCommand mockCommand = _mockery.DynamicMock< IDbCommand >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockConfiguration.ConnectionString( ) ).Return( connectionString );
				SetupResult.For( _mockConfiguration.ProviderName( ) ).Return( providerName );
				SetupResult.For( _mockProviderFactory.CreateConnectionFor( providerName ) ).Return( mockConnection );

				Expect.Call( mockConnection.CreateCommand( ) ).Return( mockCommand );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).CreateCommandFor( "" );
			}
		}

		[RowTest]
		[Row( "Select * From Auctions" )]
		[Row( "Select * From Pets" )]
		public void Should_set_the_commands_text_and_type( string sqlQuery ) {
			string providerName = "System.Data.SqlClient";
			string connectionString = "MyConnectionString";

			IDbConnection mockConnection = _mockery.DynamicMock< IDbConnection >( );
			IDbCommand mockCommand = _mockery.DynamicMock< IDbCommand >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockConfiguration.ConnectionString( ) ).Return( connectionString );
				SetupResult.For( _mockConfiguration.ProviderName( ) ).Return( providerName );
				SetupResult.For( _mockProviderFactory.CreateConnectionFor( providerName ) ).Return( mockConnection );
				SetupResult.For( mockConnection.CreateCommand( ) ).Return( mockCommand );

				mockCommand.CommandText = sqlQuery;
				mockCommand.CommandType = CommandType.Text;
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).CreateCommandFor( sqlQuery );
			}
		}

		[Test]
		public void Should_return_new_database_command() {
			string providerName = "System.Data.SqlClient";
			string connectionString = "MyConnectionString";

			IDbConnection mockConnection = _mockery.DynamicMock< IDbConnection >( );
			IDbCommand mockCommand = _mockery.DynamicMock< IDbCommand >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockConfiguration.ConnectionString( ) ).Return( connectionString );
				SetupResult.For( _mockConfiguration.ProviderName( ) ).Return( providerName );
				SetupResult.For( _mockProviderFactory.CreateConnectionFor( providerName ) ).Return( mockConnection );
				SetupResult.For( mockConnection.CreateCommand( ) ).Return( mockCommand );
			}

			using ( _mockery.Playback( ) ) {
				Assert.IsNotNull( CreateSUT( ).CreateCommandFor( "" ) );
			}
		}

		[Test]
		public void Should_close_connection_when_disposed() {
			string providerName = "System.Data.SqlClient";
			string connectionString = "MyConnectionString";

			IDbConnection mockConnection = _mockery.DynamicMock< IDbConnection >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockConfiguration.ConnectionString( ) ).Return( connectionString );
				SetupResult.For( _mockConfiguration.ProviderName( ) ).Return( providerName );
				SetupResult.For( _mockProviderFactory.CreateConnectionFor( providerName ) ).Return( mockConnection );

				mockConnection.Close( );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Dispose( );
			}
		}

		[Test]
		public void Should_open_connection_when_created() {
			string providerName = "System.Data.SqlClient";
			string connectionString = "MyConnectionString";

			IDbConnection mockConnection = _mockery.DynamicMock< IDbConnection >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockConfiguration.ConnectionString( ) ).Return( connectionString );
				SetupResult.For( _mockConfiguration.ProviderName( ) ).Return( providerName );
				SetupResult.For( _mockProviderFactory.CreateConnectionFor( providerName ) ).Return( mockConnection );

				mockConnection.Open( );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( );
			}
		}
	}
}