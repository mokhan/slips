using System;

namespace Marina.Domain.Interfaces {
	public interface IDateRange {
		DateTime Start();

		DateTime End();
	}
}