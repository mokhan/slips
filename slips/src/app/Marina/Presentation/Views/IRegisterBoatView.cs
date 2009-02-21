using System.Collections.Generic;
using Marina.Presentation.DTO;

namespace Marina.Presentation.Views {
	public interface IRegisterBoatView {
		void Display( IEnumerable< DisplayResponseLineDTO > response );
	}
}