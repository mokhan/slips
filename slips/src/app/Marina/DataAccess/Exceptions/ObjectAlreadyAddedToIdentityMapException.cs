using System;
using Marina.Domain.Interfaces;

namespace Marina.DataAccess.Exceptions {
	public class ObjectAlreadyAddedToIdentityMapException : Exception {
		public ObjectAlreadyAddedToIdentityMapException( IDomainObject domainObject )
			: base( "With ID Of: " + domainObject.ID( ) ) {}
	}
}