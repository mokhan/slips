using System.Collections.Generic;
using Marina.Domain.Interfaces;
using Marina.Infrastructure;
using Marina.Presentation.DTO;

namespace Marina.Task.Mappers {
	public interface IBrokenRulesToDisplayItemMapper :
		IMapper< IEnumerable< IBrokenRule >, IEnumerable< DisplayResponseLineDTO > > {}
}