using Marina.DataAccess;
using Marina.DataAccess.Builders;
using Marina.DataAccess.DataMappers;
using Marina.DataAccess.Schemas;
using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Infrastructure.Container;
using Marina.Test.Utility;
using MbUnit.Framework;

namespace Marina.Test.Integration.DataAccess.Mappers {
	[TestFixture]
	public class RegistrationDataMapperTest {
		public IRegistrationDataMapper CreateSUT() {
			return new RegistrationDataMapper( );
		}

		[RunInRealContainer]
		[Test]
		public void Should_be_able_to_find_john() {
			int customerId = 1000;
			IRegistration registration = CreateSUT( ).For( customerId );
			Assert.AreEqual( "John", registration.FirstName( ) );
			Assert.AreEqual( "Doe", registration.LastName( ) );
			Assert.AreEqual( "555-545-1212", registration.PhoneNumber( ) );
			Assert.AreEqual( "Phoenix", registration.City( ) );
		}

		[RunInRealContainer]
		[Test]
		[RollBack]
		public void Should_be_able_to_insert_new_registration_for_customer() {
			IRegistrationDataMapper mapper = CreateSUT( );
			long customerId = CreateCustomerRecord( );
			IRegistration expectedRegistration =
				new CustomerRegistration( "mokhan", "password", "mo", "khan", "4036813389", "calgary" );

			mapper.Insert( expectedRegistration, customerId );
			IRegistration actualRegistration = mapper.For( customerId );
			Assert.AreEqual( expectedRegistration, actualRegistration );
		}

		[RunInRealContainer]
		[Test]
		[RollBack]
		public void Should_be_able_to_update_record() {
			IRegistrationDataMapper mapper = CreateSUT( );
			long customerId = CreateCustomerRecord( );
			IRegistration firstRegistration =
				new CustomerRegistration( "mokhan", "password", "mo", "khan", "4036813389", "calgary" );
			IRegistration expectedRegistration =
				new CustomerRegistration( "khanmo", "wordpass", "om", "ankh", "1338940368", "garycal" );

			mapper.Insert( firstRegistration, customerId );
			mapper.Update( expectedRegistration, customerId );

			IRegistration actualRegistration = mapper.For( customerId );
			Assert.AreEqual( expectedRegistration, actualRegistration );
		}

		private long CreateCustomerRecord() {
			IQuery query = DatabaseInsert.Into( CustomerTable.TableName )
				.AddValue( CustomerTable.FirstName, string.Empty )
				.AddValue( CustomerTable.LastName, string.Empty )
				.AddValue( CustomerTable.Phone, string.Empty )
				.AddValue( CustomerTable.City, string.Empty ).Build( );
			return Resolve.DependencyFor< IDatabaseGateway >( ).ExecuteScalar( query );
		}
	}
}