using Marina.DataAccess.Repositories;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using Marina.Test.Utility;
using MbUnit.Framework;

namespace Marina.Test.Integration.DataAccess.Repositories {
	[TestFixture]
	public class DockRepositoryTest {
		public IDockRepository CreateSUT() {
			return new DockRepository( );
		}

		[RunInRealContainer]
		[RowTest]
		[Row( 1 )]
		[Row( 2 )]
		[Row( 3 )]
		public void Should_load_dock_by( long dockId ) {
			IDock dock = CreateSUT( ).FindBy( dockId );
			Assert.AreEqual( dockId, dock.ID( ) );
		}
	}
}