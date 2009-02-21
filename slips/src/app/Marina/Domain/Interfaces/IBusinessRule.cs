using Marina.Domain.Interfaces;

namespace Marina.Domain.Interfaces {
	internal interface IBusinessRule {
		bool IsBroken();

		IBrokenRule Description();
	}
}