using Marina.DataAccess.Builders;
using Marina.DataAccess.Schemas;
using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Infrastructure.Container;

namespace Marina.DataAccess.DataMappers {
	public class CustomerDataMapper : ICustomerDataMapper {
		public CustomerDataMapper() : this
			(
			Resolve.DependencyFor< IDatabaseGateway >( ),
			Resolve.DependencyFor< IBoatDataMapper >( ),
			Resolve.DependencyFor< ILeaseDataMapper >( ),
			Resolve.DependencyFor< IRegistrationDataMapper >( )
			) {}

		public CustomerDataMapper( IDatabaseGateway gateway, IBoatDataMapper boatMapper, ILeaseDataMapper leaseMapper,
		                           IRegistrationDataMapper registrationMapper ) {
			_gateway = gateway;
			_boatMapper = boatMapper;
			_leaseMapper = leaseMapper;
			_registrationMapper = registrationMapper;
		}

		public ICustomer FindBy( long customerId ) {
			if ( customerId > 0 ) {
				return new Customer( customerId,
				                     _boatMapper.AllBoatsFor( customerId ),
				                     _leaseMapper.AllLeasesFor( customerId ),
				                     _registrationMapper.For( customerId ) );
			}
			return null;
		}

		public ICustomer FindBy( string username ) {
			IDatabaseRow row = _gateway.LoadRowUsing( Queries.SelectCustomerBy( username ) );
			return FindBy( row.From< long >( AuthorizationTable.CustomerID ) );
		}

		public void Insert( ICustomer customer ) {
			using ( IDatabaseTransaction workUnit = new DatabaseTransaction( ) ) {
				customer.ChangeIdTo( _gateway.ExecuteScalar( Queries.Insert( ) ) );
				_registrationMapper.Insert( customer.Registration( ), customer.ID( ) );
				_boatMapper.Insert( customer.RegisteredBoats( ), customer.ID( ) );
				_leaseMapper.Insert( customer.Leases( ), customer.ID( ) );
				workUnit.Commit( );
			}
		}

		public void Update( ICustomer customer ) {
			using ( IDatabaseTransaction workUnit = new DatabaseTransaction( ) ) {
				_registrationMapper.Update( customer.Registration( ), customer.ID( ) );
				_boatMapper.Update( customer.RegisteredBoats( ), customer.ID( ) );
				_leaseMapper.Update( customer.Leases( ), customer.ID( ) );
				workUnit.Commit( );
			}
		}

		private readonly IDatabaseGateway _gateway;
		private readonly IBoatDataMapper _boatMapper;
		private readonly ILeaseDataMapper _leaseMapper;
		private readonly IRegistrationDataMapper _registrationMapper;

		private static class Queries {
			public static IQuery Insert() {
				return DatabaseInsert.Into( CustomerTable.TableName )
					.AddValue( CustomerTable.FirstName, string.Empty )
					.AddValue( CustomerTable.LastName, string.Empty )
					.AddValue( CustomerTable.Phone, string.Empty )
					.AddValue( CustomerTable.City, string.Empty ).Build( );
			}

			public static IQuery SelectCustomerBy( string username ) {
				return DatabaseSelect.From( AuthorizationTable.TableName )
					.AddColumn( AuthorizationTable.CustomerID )
					.AddColumn( AuthorizationTable.UserName )
					.Where( AuthorizationTable.UserName, "'" + username + "'" )
					.Build( );
			}
		}
	}
}