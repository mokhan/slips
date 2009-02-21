using Marina.DataAccess.DataMappers;
using Marina.Domain.Interfaces;
using Marina.Test.Integration.DataAccess.Utility;
using Marina.Test.Utility;
using MbUnit.Framework;

namespace Marina.Test.Integration.DataAccess.Mappers {
	public class CustomerDataMapperTest {
		public ICustomerDataMapper CreateSUT() {
			return new CustomerDataMapper( );
		}

		[Test]
		[RollBack]
		[RunInRealContainer]
		public void Should_be_able_to_find_customer_by_username() {
			string username = "mokhan";
			long customerId = CustomerMother.CreateCustomerRecordWith( username );

			ICustomer foundCustomer = CreateSUT( ).FindBy( username );
			Assert.AreEqual( customerId, foundCustomer.ID( ) );
			Assert.AreEqual( username, foundCustomer.Registration( ).Username( ) );
		}
	}
}