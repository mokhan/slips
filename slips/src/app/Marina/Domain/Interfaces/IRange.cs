using System;

namespace Marina.Domain.Interfaces {
	public interface IRange< T > where T : IComparable< T > {
		T Start();

		T End();

		bool Contains( T value );
	}
}