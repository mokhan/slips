using Marina.Web.Http;

namespace Marina.Web.Views {
	public class WebView< T > : IWebView< T > {
		public WebView( string name, IViewLuggageTransporter< T > viewBag, IHttpGateway gateway ) {
			this.name = name;
			this.gateway = gateway;
			this.viewBag = viewBag;
		}

		public string Name() {
			return name;
		}

		public void Render() {
			gateway.RedirectTo( this );
		}

		public void AddToBag( T slips ) {
			viewBag.Add( slips );
		}

		private readonly string name;
		private readonly IHttpGateway gateway;
		private readonly IViewLuggageTransporter< T > viewBag;
	}
}