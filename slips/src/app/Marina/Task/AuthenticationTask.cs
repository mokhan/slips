using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using Marina.Presentation.DTO;
using Marina.Web.Http;

namespace Marina.Task {
	public class AuthenticationTask : IAuthenticationTask {
		public AuthenticationTask( ICustomerRepository customers, IHttpGateway gateway ) {
			_customers = customers;
			_gateway = gateway;
		}

		public DisplayResponseLineDTO AuthenticateUserUsing( LoginCredentialsDTO credentials ) {
			if ( CheckIfPasswordMatches( credentials, _customers.FindBy( credentials.Username ) ) ) {
				_gateway.AddAuthenticationCookieFor( credentials.Username, _customers.FindBy( credentials.Username ).ID( ) );
				return ValidCredentialsMessage( credentials.Username );
			}
			else {
				return InvalidCredentialsMessage( );
			}
		}

		private static DisplayResponseLineDTO ValidCredentialsMessage( string username ) {
			return new DisplayResponseLineDTO( string.Format( "Currently logged in as {0}", username ) );
		}

		private static DisplayResponseLineDTO InvalidCredentialsMessage() {
			return new DisplayResponseLineDTO( "Invalid credentials specified" );
		}

		private static bool CheckIfPasswordMatches( LoginCredentialsDTO credentials, ICustomer customer ) {
			if ( customer != null && customer.Registration( ) != null ) {
				return customer.Registration( ).Password( ).Equals( credentials.Password );
			}
			return false;
		}

		private readonly ICustomerRepository _customers;
		private readonly IHttpGateway _gateway;
	}
}