using System;
using Marina.DataAccess.Builders;

namespace Marina.DataAccess {
	public interface IDatabaseConnection : IDisposable {
		IDatabaseCommand CreateCommandFor( string sqlQuery );

		IDatabaseCommand CreateCommandFor( IQuery query );
	}
}