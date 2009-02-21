using System.Data;

namespace Marina.DataAccess.Builders {
	public interface IQuery {
		void Prepare( IDbCommand command );
	}
}