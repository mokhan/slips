using System.Collections.Generic;
using Marina.Presentation.DTO;

namespace Marina.Presentation.Views {
	public interface IUpdateRegistrationView {
		void Display( CustomerRegistrationDisplayDTO customerRegistration );
		void Display( IEnumerable< DisplayResponseLineDTO > response );
	}
}