using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Presentation.DTO;

namespace Marina.Task.Mappers {
	public class DockToDisplayDTOMapper : IDockToDisplayDTOMapper {
		public DockDisplayDTO MapFrom( IDock input ) {
			return
				new DockDisplayDTO(
					input.Name( ),
					input.Location( ).Name( ),
					input.IsUtilityEnabled( Utilities.Water ).ToString( ),
					input.IsUtilityEnabled( Utilities.Electrical ).ToString( ) );
		}
	}
}