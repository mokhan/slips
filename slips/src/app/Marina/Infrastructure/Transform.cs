namespace Marina.Infrastructure {
	public class Transform {
		public static ITransformer From( object item ) {
			return new Transformer( item );
		}
	}
}