using System.Collections.Generic;
using Marina.Presentation.DTO;

namespace Marina.Task {
	public interface IRegistrationTasks {
		IEnumerable< DisplayResponseLineDTO > RegisterNew( RegisterCustomerDTO customer );

		IEnumerable< DisplayResponseLineDTO > AddNewBoatUsing( BoatRegistrationDTO boat );

		CustomerRegistrationDisplayDTO LoadRegistrationFor( long customerId );

		IEnumerable< DisplayResponseLineDTO > UpdateRegistrationFor( UpdateCustomerRegistrationDTO registration );

		IEnumerable< BoatRegistrationDTO > AllBoatsFor( long customerId );
	}
}