using Marina.Infrastructure;
using Marina.Web.Http;

namespace Marina.Web.Handlers {
	public interface IRequestHandler : ISpecification< IHttpGateway >, ICommand {}
}