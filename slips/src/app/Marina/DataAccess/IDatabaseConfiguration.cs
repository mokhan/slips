namespace Marina.DataAccess {
	public interface IDatabaseConfiguration {
		string ConnectionString();

		string ProviderName();
	}
}