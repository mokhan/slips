using System.Collections.Generic;
using System.Data;
using Marina.DataAccess.Builders;

namespace Marina.DataAccess {
	public interface IDatabaseGateway {
		DataTable LoadTableUsing( string sqlQuery );

		IEnumerable< IDatabaseRow > FindAllRowsMatching( IQuery query );

		void Execute( params IQuery[] queries );

		void Execute( IEnumerable< IQuery > queries );

		long ExecuteScalar( IQuery query );

		IDatabaseRow LoadRowUsing( IQuery query );
	}
}