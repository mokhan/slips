using System;

namespace Marina.Domain.Interfaces {
	public interface ISlipLease {
		ILeaseDuration Duration();

		DateTime StartDate();

		DateTime ExpiryDate();

		ISlip Slip();
	}
}