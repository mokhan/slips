namespace Marina.DataAccess.Schemas {
	public static class BoatTable {
		public const string TableName = "Boat";
		public static readonly DatabaseColumn BoatID = new DatabaseColumn( TableName, "BoatID" );
		public static readonly DatabaseColumn RegistrationNumber = new DatabaseColumn( TableName, "RegistrationNumber" );
		public static readonly DatabaseColumn Manufacturer = new DatabaseColumn( TableName, "Manufacturer" );
		public static readonly DatabaseColumn ModelYear = new DatabaseColumn( TableName, "ModelYear" );
		public static readonly DatabaseColumn Length = new DatabaseColumn( TableName, "Length" );
		public static readonly DatabaseColumn CustomerID = new DatabaseColumn( TableName, "CustomerID" );
	}
}