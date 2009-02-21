using Marina.Infrastructure;
using Marina.Presentation.DTO;
using Marina.Presentation.Views;

namespace Marina.Presentation.Mappers {
	public interface ICustomerRegistrationPresentationMapper :
		IMapper< ICustomerRegistrationView, RegisterCustomerDTO > {}
}