using Marina.Domain.Interfaces;
using Marina.Presentation.DTO;

namespace Marina.Task.Mappers {
	public class SlipsToDisplayDTOMapper : ISlipsToDisplayDTOMapper {
		public SlipDisplayDTO MapFrom( ISlip input ) {
			return
				new SlipDisplayDTO( input.Dock( ).ID( ).ToString( ),
				                    input.Dock( ).Name( ),
				                    input.Width( ).ToString( ),
				                    input.Length( ).ToString( ),
				                    input.Location( ).Name( ),
				                    input.ID( ).ToString( ) );
		}
	}
}