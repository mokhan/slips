using Marina.Infrastructure;
using Marina.Presentation.DTO;
using Marina.Web;

namespace Marina.Presentation.Mappers {
	public interface ILoginCredentialsMapper : IMapper< IHttpRequest, LoginCredentialsDTO > {}
}