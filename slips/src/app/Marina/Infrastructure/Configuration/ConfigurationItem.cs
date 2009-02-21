namespace Marina.Infrastructure.Configuration {
	public class ConfigurationItem< T > {
		private T item;

		public ConfigurationItem( T item ) {
			this.item = item;
		}

		public T Value( ) {
			return item;
		}
	}
}