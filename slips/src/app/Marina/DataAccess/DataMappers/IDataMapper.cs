namespace Marina.DataAccess.DataMappers {
	public interface IDataMapper< T > {
		T FindBy( long id );
	}
}