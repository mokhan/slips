namespace Marina.DataAccess.Schemas {
	public static class AuthorizationTable {
		public const string TableName = "Authorize";
		public static readonly DatabaseColumn AuthID = new DatabaseColumn( TableName, "AuthID" );
		public static readonly DatabaseColumn UserName = new DatabaseColumn( TableName, "UserName" );
		public static readonly DatabaseColumn Password = new DatabaseColumn( TableName, "Password" );
		public static readonly DatabaseColumn CustomerID = new DatabaseColumn( TableName, "CustomerID" );
	}
}