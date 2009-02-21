namespace Marina.DataAccess.Schemas {
	public static class CustomerTable {
		public const string TableName = "Customer";
		public static readonly DatabaseColumn CustomerID = new DatabaseColumn( TableName, "CustomerID" );
		public static readonly DatabaseColumn FirstName = new DatabaseColumn( TableName, "FirstName" );
		public static readonly DatabaseColumn LastName = new DatabaseColumn( TableName, "LastName" );
		public static readonly DatabaseColumn Phone = new DatabaseColumn( TableName, "Phone" );
		public static readonly DatabaseColumn City = new DatabaseColumn( TableName, "City" );
	}
}