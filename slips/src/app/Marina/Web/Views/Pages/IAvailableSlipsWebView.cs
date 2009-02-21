using System.Collections.Generic;
using Marina.Presentation.DTO;

namespace Marina.Web.Views.Pages {
	public interface IAvailableSlipsWebView : IWebView< IEnumerable< SlipDisplayDTO > > {}
}