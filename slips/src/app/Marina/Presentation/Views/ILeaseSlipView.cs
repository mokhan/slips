using Marina.Presentation.DTO;

namespace Marina.Presentation.Views {
	public interface ILeaseSlipView {
		void Display( SlipDisplayDTO slip );

		void Display( DisplayResponseLineDTO response );
	}
}