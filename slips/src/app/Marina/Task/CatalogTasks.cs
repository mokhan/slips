using System.Collections.Generic;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using Marina.Infrastructure.Container;
using Marina.Presentation.DTO;
using Marina.Task.Mappers;

namespace Marina.Task {
	public class CatalogTasks : ICatalogTasks {
		public CatalogTasks()
			: this(
				Resolve.DependencyFor< ISlipsRepository >( ),
				Resolve.DependencyFor< ISlipsToDisplayDTOMapper >( ),
				Resolve.DependencyFor< IDockRepository >( ),
				Resolve.DependencyFor< IDockToDisplayDTOMapper >( )
				) {}

		public CatalogTasks( ISlipsRepository slipRepository, ISlipsToDisplayDTOMapper slipMapper,
		                     IDockRepository dockRepository, IDockToDisplayDTOMapper dockMapper ) {
			_slips = slipRepository;
			_slipMapper = slipMapper;
			_docks = dockRepository;
			_dockMapper = dockMapper;
		}

		public IEnumerable< SlipDisplayDTO > GetAvailableSlipsForDockBy( long dockId ) {
			IDock dock = _docks.FindBy( dockId );
			foreach ( ISlip slip in _slips.AllAvailableSlipsFor( dock ) ) {
				yield return _slipMapper.MapFrom( slip );
			}
		}

		public DockDisplayDTO GetDockInformationBy( long dockId ) {
			return _dockMapper.MapFrom( _docks.FindBy( dockId ) );
		}

		public IEnumerable< SlipDisplayDTO > GetAllAvailableSlips() {
			foreach ( ISlip availableSlip in _slips.AllAvailableSlips( ) ) {
				yield return _slipMapper.MapFrom( availableSlip );
			}
		}

		public SlipDisplayDTO FindSlipBy( long slipId ) {
			return _slipMapper.MapFrom( _slips.FindBy( slipId ) );
		}

		private readonly ISlipsRepository _slips;
		private readonly ISlipsToDisplayDTOMapper _slipMapper;
		private readonly IDockRepository _docks;
		private readonly IDockToDisplayDTOMapper _dockMapper;
	}
}