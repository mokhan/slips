namespace Marina.Web.Views {
	public interface IWebView< T > : IView {
		void AddToBag( T slips );
	}
}