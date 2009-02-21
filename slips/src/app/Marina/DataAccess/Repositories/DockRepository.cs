using Marina.DataAccess.DataMappers;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using Marina.Infrastructure.Container;

namespace Marina.DataAccess.Repositories {
	public class DockRepository : IDockRepository {
		public DockRepository() : this( Resolve.DependencyFor< IDockDataMapper >( ) ) {}

		public DockRepository( IDockDataMapper mapper ) {
			this.mapper = mapper;
		}

		public IDock FindBy( long dockId ) {
			return mapper.FindBy( dockId );
		}

		private readonly IDockDataMapper mapper;
	}
}