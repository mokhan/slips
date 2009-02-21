using Marina.DataAccess.DataMappers;
using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using Marina.Infrastructure.Container;

namespace Marina.DataAccess.Repositories {
	public class CustomerRepository : ICustomerRepository {
		public CustomerRepository()
			: this( new IdentityMap< ICustomer >( ), Resolve.DependencyFor< ICustomerDataMapper >( ) ) {}

		public CustomerRepository( IIdentityMap< ICustomer > identityMap, ICustomerDataMapper mapper ) {
			_identityMap = identityMap;
			_mapper = mapper;
		}

		public ICustomer FindBy( long customerId ) {
			if ( _identityMap.ContainsObjectWithIdOf( customerId ) ) {
				return _identityMap.FindObjectWithIdOf( customerId );
			}
			return FindCustomerBy( customerId );
		}

		public ICustomer FindBy( string username ) {
			return _mapper.FindBy( username );
		}

		public void Save( ICustomer customer ) {
			if ( _identityMap.ContainsObjectWithIdOf( customer.ID( ) ) ) {
				_mapper.Update( customer );
			}
			else {
				_mapper.Insert( customer );
				_identityMap.Add( customer );
			}
		}

		public ICustomer NewCustomer() {
			return new Customer( );
		}

		private ICustomer FindCustomerBy( long customerId ) {
			ICustomer customer = _mapper.FindBy( customerId );
			_identityMap.Add( customer );
			return customer;
		}

		private readonly IIdentityMap< ICustomer > _identityMap;
		private readonly ICustomerDataMapper _mapper;
	}
}