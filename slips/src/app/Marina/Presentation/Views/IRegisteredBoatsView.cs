using System.Collections.Generic;
using Marina.Presentation.DTO;

namespace Marina.Presentation.Views {
	public interface IRegisteredBoatsView {
		void Display( IEnumerable< BoatRegistrationDTO > boats );
	}
}