namespace Marina.DataAccess.Schemas {
	public static class LeaseTable {
		public const string TableName = "Lease";
		public static readonly DatabaseColumn ID = new DatabaseColumn( TableName, "LeaseID" );
		public static readonly DatabaseColumn StartDate = new DatabaseColumn( TableName, "StartDate" );
		public static readonly DatabaseColumn EndDate = new DatabaseColumn( TableName, "EndDate" );
		public static readonly DatabaseColumn SlipID = new DatabaseColumn( TableName, "SlipID" );
		public static readonly DatabaseColumn CustomerID = new DatabaseColumn( TableName, "CustomerID" );
		public static readonly DatabaseColumn LeaseTypeID = new DatabaseColumn( TableName, "LeaseTypeID" );
	}
}