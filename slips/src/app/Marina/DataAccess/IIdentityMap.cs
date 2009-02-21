namespace Marina.DataAccess {
	public interface IIdentityMap< T > {
		void Add( T domainObject );

		bool ContainsObjectWithIdOf( long idOfObjectToFind );

		T FindObjectWithIdOf( long idOfObjectToFind );
	}
}