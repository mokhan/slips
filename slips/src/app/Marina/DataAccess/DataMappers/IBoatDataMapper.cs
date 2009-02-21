using System.Collections.Generic;
using Marina.Domain.Interfaces;

namespace Marina.DataAccess.DataMappers {
	public interface IBoatDataMapper {
		IEnumerable< IBoat > AllBoatsFor( long customerId );

		void Insert( IEnumerable< IBoat > boats, long forCustomerId );

		void Update( IEnumerable< IBoat > boats, long forCustomerId );
	}
}