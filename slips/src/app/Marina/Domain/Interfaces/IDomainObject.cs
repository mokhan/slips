namespace Marina.Domain.Interfaces {
	public interface IDomainObject {
		long ID();

		void ChangeIdTo( long id );
	}
}