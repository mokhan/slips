using Marina.Domain.Interfaces;

namespace Marina.DataAccess.DataMappers {
	public interface ICustomerDataMapper : IDataMapper< ICustomer > {
		void Insert( ICustomer customer );

		void Update( ICustomer customer );

		ICustomer FindBy( string username );
	}
}