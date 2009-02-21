using System.Collections.Generic;
using System.Web.Services;
using Marina.Infrastructure.Container;
using Marina.Presentation.DTO;
using Marina.Task;

namespace Marina.Web.Services {
	public class RegistrationWebServices {
		public RegistrationWebServices() : this( Resolve.DependencyFor< IRegistrationTasks >( ) ) {}

		public RegistrationWebServices( IRegistrationTasks underlyingTask ) {
			_underlyingTask = underlyingTask;
		}

		public IEnumerable< DisplayResponseLineDTO > RegisterNew( RegisterCustomerDTO customer ) {
			return _underlyingTask.RegisterNew( customer );
		}

		public IEnumerable< DisplayResponseLineDTO > AddNewBoatUsing( BoatRegistrationDTO boat ) {
			return _underlyingTask.AddNewBoatUsing( boat );
		}

		[WebMethod]
		public CustomerRegistrationDisplayDTO LoadRegistrationFor( long customerId ) {
			return _underlyingTask.LoadRegistrationFor( customerId );
		}

		public IEnumerable< DisplayResponseLineDTO > UpdateRegistrationFor( UpdateCustomerRegistrationDTO registration ) {
			return _underlyingTask.UpdateRegistrationFor( registration );
		}

		public IEnumerable< BoatRegistrationDTO > AllBoatsFor( long customerId ) {
			return _underlyingTask.AllBoatsFor( customerId );
		}

		private readonly IRegistrationTasks _underlyingTask;
	}
}