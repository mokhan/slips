namespace Marina.Domain.Interfaces {
	public interface IDock {
		long ID();

		string Name();

		ILocation Location();

		bool IsUtilityEnabled( IUtility utility );
	}
}