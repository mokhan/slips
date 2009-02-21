namespace Marina.Infrastructure {
	public interface IMapper< TIn, TOut > {
		TOut MapFrom( TIn input );
	}
}