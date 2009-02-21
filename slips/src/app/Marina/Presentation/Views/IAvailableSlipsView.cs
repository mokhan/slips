using System.Collections.Generic;
using Marina.Presentation.DTO;

namespace Marina.Presentation.Views {
	public interface IAvailableSlipsView {
		void Display( IEnumerable< SlipDisplayDTO > availableSlips );
	}
}