using System.Configuration;
using Marina.DataAccess;
using MbUnit.Framework;

namespace Marina.Test.Unit.DataAccess {
	[TestFixture]
	public class DatabaseConfigurationTest {
		private ConnectionStringSettings _settings;

		[SetUp]
		public void Setup() {
			_settings = new ConnectionStringSettings( "ConnectionName", string.Empty, string.Empty );
		}

		public IDatabaseConfiguration CreateSUT() {
			return new DatabaseConfiguration( _settings );
		}

		[Test]
		public void Should_return_connection_string() {
			string connectionString = "MyConnectionString";
			_settings.ConnectionString = connectionString;
			Assert.AreEqual( connectionString, CreateSUT( ).ConnectionString( ) );
		}

		[Test]
		public void Should_return_the_provider_name() {
			string providerName = "MyProvider";
			_settings.ProviderName = providerName;
			Assert.AreEqual( providerName, CreateSUT( ).ProviderName( ) );
		}
	}
}