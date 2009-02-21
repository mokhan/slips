using Marina.Domain.Interfaces;

namespace Marina.Domain.Repositories {
	public interface ICustomerRepository {
		ICustomer FindBy( long customerId );

		ICustomer FindBy( string username );

		void Save( ICustomer customer );

		ICustomer NewCustomer();
	}
}