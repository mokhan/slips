namespace Marina.Web.Views {
	public interface IViewLuggageTransporter< T > {
		void Add( T value );

		T Value( );
	}
}