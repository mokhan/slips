using System.Collections.Generic;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using Marina.Infrastructure;
using Marina.Presentation.DTO;
using Marina.Task;
using Marina.Task.Mappers;
using Marina.Test.Utility;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Task {
	[TestFixture]
	public class CatalogTasksTest {
		private MockRepository _mockery;
		private ISlipsRepository _slipRepository;
		private ISlipsToDisplayDTOMapper _slipMapper;
		private IDockRepository _dockRepository;
		private IDockToDisplayDTOMapper _dockMapper;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_slipRepository = _mockery.DynamicMock< ISlipsRepository >( );
			_dockRepository = _mockery.DynamicMock< IDockRepository >( );
			_slipMapper = _mockery.DynamicMock< ISlipsToDisplayDTOMapper >( );
			_dockMapper = _mockery.DynamicMock< IDockToDisplayDTOMapper >( );
		}

		public ICatalogTasks CreateSUT() {
			return new CatalogTasks( _slipRepository, _slipMapper, _dockRepository, _dockMapper );
		}

		[Test]
		public void Should_leverage_mapper_to_map_all_slips() {
			IList< ISlip > availableSlips = new List< ISlip >( );
			ISlip slip = _mockery.DynamicMock< ISlip >( );

			availableSlips.Add( slip );

			SlipDisplayDTO slipDTO = ObjectMother.SlipDisplayDTO( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _slipRepository.AllAvailableSlips( ) ).Return( availableSlips );
				Expect.Call( _slipMapper.MapFrom( slip ) ).Return( slipDTO );
			}

			using ( _mockery.Playback( ) ) {
				IEnumerable< SlipDisplayDTO > allAvailableSlips = CreateSUT( ).GetAllAvailableSlips( );
				Assert.IsTrue( ListFactory.From( allAvailableSlips ).Contains( slipDTO ) );
			}
		}

		[Test]
		public void Should_leverage_repository_to_find_dock_by_id() {
			long dockId = 1;
			IDock dock = _mockery.DynamicMock< IDock >( );

			using ( _mockery.Record( ) ) {
				Expect.Call( _dockRepository.FindBy( dockId ) ).Return( dock );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).GetDockInformationBy( dockId );
			}
		}

		[Test]
		public void Should_leverage_mapper_to_return_dto() {
			long dockId = 1;
			IDock dock = _mockery.DynamicMock< IDock >( );

			DockDisplayDTO dto = ObjectMother.DockDisplayDTO( );
			using ( _mockery.Record( ) ) {
				SetupResult.For( _dockRepository.FindBy( dockId ) ).Return( dock );
				Expect.Call( _dockMapper.MapFrom( dock ) ).Return( dto );
			}

			using ( _mockery.Playback( ) ) {
				Assert.AreEqual( dto, CreateSUT( ).GetDockInformationBy( dockId ) );
			}
		}

		[Test]
		public void Should_leverage_repository_to_find_dock() {
			long dockId = 1;
			IDock dock = _mockery.DynamicMock< IDock >( );
			ISlip slip = _mockery.DynamicMock< ISlip >( );

			IList< ISlip > availableSlipsForDock = new List< ISlip >( );
			availableSlipsForDock.Add( slip );

			SlipDisplayDTO dto = ObjectMother.SlipDisplayDTO( );
			using ( _mockery.Record( ) ) {
				Expect.Call( _dockRepository.FindBy( dockId ) ).Return( dock );
				Expect.Call( _slipRepository.AllAvailableSlipsFor( dock ) ).Return( availableSlipsForDock );
				Expect.Call( _slipMapper.MapFrom( slip ) ).Return( dto );
			}

			using ( _mockery.Playback( ) ) {
				IRichList< SlipDisplayDTO > slipsFound = ListFactory.From( CreateSUT( ).GetAvailableSlipsForDockBy( dockId ) );
				Assert.IsTrue( slipsFound.Contains( dto ) );
			}
		}
	}
}