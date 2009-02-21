using Marina.DataAccess.Builders;
using Marina.DataAccess.Schemas;
using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Infrastructure.Container;

namespace Marina.DataAccess.DataMappers {
	public class RegistrationDataMapper : IRegistrationDataMapper {
		public RegistrationDataMapper() : this( Resolve.DependencyFor< IDatabaseGateway >( ) ) {}

		public RegistrationDataMapper( IDatabaseGateway gateway ) {
			_gateway = gateway;
		}

		public IRegistration For( long customerId ) {
			return Mappers.From( _gateway.LoadRowUsing( Queries.SelectRegistrationFor( customerId ) ) );
		}

		public void Insert( IRegistration registration, long forCustomerId ) {
			using ( IDatabaseTransaction unitOfWork = new DatabaseTransaction( ) ) {
				_gateway.Execute( Queries.Insert( registration, forCustomerId ),
				                  Queries.UpdateCustomer( registration, forCustomerId ) );
				unitOfWork.Commit( );
			}
		}

		public void Update( IRegistration registration, long forCustomerId ) {
			using ( IDatabaseTransaction unitOfWork = new DatabaseTransaction( ) ) {
				_gateway.Execute( Queries.UpdateCustomer( registration, forCustomerId ),
				                  Queries.UpdateAuthorization( registration, forCustomerId ) );
				unitOfWork.Commit( );
			}
		}

		private readonly IDatabaseGateway _gateway;

		private class Queries {
			public static IQuery SelectRegistrationFor( long customerId ) {
				return DatabaseSelect.From( CustomerTable.TableName )
					.AddColumn( CustomerTable.FirstName )
					.AddColumn( CustomerTable.LastName )
					.AddColumn( CustomerTable.Phone )
					.AddColumn( CustomerTable.City )
					.AddColumn( AuthorizationTable.UserName )
					.AddColumn( AuthorizationTable.Password )
					.InnerJoinOn( AuthorizationTable.CustomerID, CustomerTable.CustomerID )
					.Where( CustomerTable.CustomerID, customerId.ToString( ) ).Build( );
			}

			public static IQuery Insert( IRegistration registration, long forCustomerId ) {
				return DatabaseInsert.Into( AuthorizationTable.TableName )
					.AddValue( AuthorizationTable.CustomerID, forCustomerId.ToString( ) )
					.AddValue( AuthorizationTable.UserName, registration.Username( ) )
					.AddValue( AuthorizationTable.Password, registration.Password( ) )
					.Build( );
			}

			public static IQuery UpdateCustomer( IRegistration registration, long forCustomerId ) {
				return DatabaseUpdate.Where( CustomerTable.CustomerID, forCustomerId )
					.Add( CustomerTable.FirstName, registration.FirstName( ) )
					.Add( CustomerTable.LastName, registration.LastName( ) )
					.Add( CustomerTable.Phone, registration.PhoneNumber( ) )
					.Add( CustomerTable.City, registration.City( ) )
					.Build( );
			}

			public static IQuery UpdateAuthorization( IRegistration registration, long forCustomerId ) {
				return DatabaseUpdate.Where( AuthorizationTable.CustomerID, forCustomerId )
					.Add( AuthorizationTable.UserName, registration.Username( ) )
					.Add( AuthorizationTable.Password, registration.Password( ) )
					.Build( );
			}
		}

		private class Mappers {
			public static IRegistration From( IDatabaseRow row ) {
				return new CustomerRegistration(
					row.From< string >( AuthorizationTable.UserName ),
					row.From< string >( AuthorizationTable.Password ),
					row.From< string >( CustomerTable.FirstName ),
					row.From< string >( CustomerTable.LastName ),
					row.From< string >( CustomerTable.Phone ),
					row.From< string >( CustomerTable.City )
					);
			}
		}
	}
}