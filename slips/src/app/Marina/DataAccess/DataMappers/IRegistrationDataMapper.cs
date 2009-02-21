using Marina.Domain.Interfaces;

namespace Marina.DataAccess.DataMappers {
	public interface IRegistrationDataMapper {
		IRegistration For( long customerId );

		void Insert( IRegistration registration, long forCustomerId );

		void Update( IRegistration registration, long forCustomerId );
	}
}