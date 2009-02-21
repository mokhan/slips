using System;
using Marina.Infrastructure;

namespace Marina.Domain.Interfaces {
	public interface ILeaseDuration : IDomainObject, ISpecification< IDateRange > {
		DateTime CalculateExpiryDateFrom( DateTime startDate );

		string Name();
	}
}