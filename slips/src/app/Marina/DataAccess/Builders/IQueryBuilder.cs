using System.Collections.Generic;

namespace Marina.DataAccess.Builders {
	public interface IQueryBuilder {
		IEnumerable< DatabaseCommandParameter > Parameters();

		IQuery Build();
	}
}