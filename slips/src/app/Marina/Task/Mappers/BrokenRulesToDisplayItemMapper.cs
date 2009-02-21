using System.Collections.Generic;
using Marina.Domain.Interfaces;
using Marina.Presentation.DTO;

namespace Marina.Task.Mappers {
	public class BrokenRulesToDisplayItemMapper : IBrokenRulesToDisplayItemMapper {
		public IEnumerable< DisplayResponseLineDTO > MapFrom( IEnumerable< IBrokenRule > input ) {
			foreach ( IBrokenRule brokenRule in input ) {
				yield return new DisplayResponseLineDTO( brokenRule.Message( ) );
			}
		}
	}
}