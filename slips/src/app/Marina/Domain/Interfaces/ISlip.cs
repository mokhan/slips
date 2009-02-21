namespace Marina.Domain.Interfaces {
	public interface ISlip : IDomainObject {
		IDock Dock();

		ILocation Location();

		int Width();

		int Length();

		ISlipLease LeaseTo( ICustomer customer, ILeaseDuration duration );

		bool IsLeased();
	}
}