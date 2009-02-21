using Marina.Presentation.DTO;
using Marina.Presentation.Views;

namespace Marina.Presentation.Mappers {
	public class CustomerRegistrationPresentationMapper : ICustomerRegistrationPresentationMapper {
		public RegisterCustomerDTO MapFrom( ICustomerRegistrationView view ) {
			return new RegisterCustomerDTO(
				view.UserName( ),
				view.Password( ),
				view.FirstName( ),
				view.LastName( ),
				view.PhoneNumber( ),
				view.City( )
				);
		}
	}
}