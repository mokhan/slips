using System.Data;

namespace Marina.DataAccess {
	public interface IDatabaseCommand {
		DataTable ExecuteQuery();

		long ExecuteScalarQuery();
	}
}