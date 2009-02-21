namespace Marina.DataAccess {
	public interface IDatabaseConnectionFactory {
		IDatabaseConnection Create();
	}
}