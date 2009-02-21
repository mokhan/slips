using Marina.DataAccess.DataMappers;
using Marina.DataAccess.Repositories;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.DataAccess.Repositories {
	[TestFixture]
	public class DockRepositoryTest {
		private MockRepository _mockery;
		private IDockDataMapper mockMapper;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			mockMapper = _mockery.DynamicMock< IDockDataMapper >( );
		}

		public IDockRepository CreateSUT() {
			return new DockRepository( mockMapper );
		}

		[Test]
		public void Should_leverage_mapper_to_retrieve_dock_by_id() {
			IDock dock = _mockery.DynamicMock< IDock >( );
			long dockId = 2;

			using ( _mockery.Record( ) ) {
				Expect.Call( mockMapper.FindBy( dockId ) ).Return( dock );
			}

			using ( _mockery.Playback( ) ) {
				Assert.AreEqual( dock, CreateSUT( ).FindBy( dockId ) );
			}
		}
	}
}