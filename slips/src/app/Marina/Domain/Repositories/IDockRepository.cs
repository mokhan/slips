using Marina.Domain.Interfaces;

namespace Marina.Domain.Repositories {
	public interface IDockRepository {
		IDock FindBy( long dockId );
	}
}