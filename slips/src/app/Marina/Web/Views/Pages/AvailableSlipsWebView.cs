using System.Collections.Generic;
using Marina.Infrastructure.Container;
using Marina.Presentation.DTO;
using Marina.Web.Http;

namespace Marina.Web.Views.Pages {
	public class AvailableSlipsWebView : WebView< IEnumerable< SlipDisplayDTO > >, IAvailableSlipsWebView {
		public AvailableSlipsWebView()
			: this(
				ViewLuggage.TransporterFor( ViewLuggageTickets.AvailableSlips ),
				Resolve.DependencyFor< IHttpGateway >( ) ) {}

		public AvailableSlipsWebView( IViewLuggageTransporter< IEnumerable< SlipDisplayDTO > > viewBag, IHttpGateway gateway )
			: base( "AvailableSlips.aspx", viewBag, gateway ) {}
	}
}