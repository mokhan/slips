using System.Collections.Generic;

namespace Marina.Infrastructure {
	internal class EnumerableMapper< TIn, TOut > : IMapper< IEnumerable< TIn >, IEnumerable< TOut > > {
		public EnumerableMapper( IMapper< TIn, TOut > mapper ) {
			_mapper = mapper;
		}

		public IEnumerable< TOut > MapFrom( IEnumerable< TIn > input ) {
			foreach ( TIn item in input ) {
				yield return _mapper.MapFrom( item );
			}
		}

		private readonly IMapper< TIn, TOut > _mapper;
	}
}