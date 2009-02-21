using System.Transactions;

namespace Marina.DataAccess {
	internal class DatabaseTransaction : IDatabaseTransaction {
		public DatabaseTransaction() {
			_scope = new TransactionScope( );
		}

		public void Commit() {
			_scope.Complete( );
		}

		public void Dispose() {
			_scope.Dispose( );
		}

		private readonly TransactionScope _scope;
	}
}