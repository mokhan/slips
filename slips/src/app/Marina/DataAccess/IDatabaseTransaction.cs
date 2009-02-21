using System;

namespace Marina.DataAccess {
	internal interface IDatabaseTransaction : IDisposable {
		void Commit();
	}
}