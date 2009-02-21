using System.Collections.Generic;
using Marina.Presentation.DTO;

namespace Marina.Presentation.Views {
	public interface IDockView {
		void Display( DockDisplayDTO dto );
		void Display( IEnumerable< SlipDisplayDTO > availableSlips );
	}
}