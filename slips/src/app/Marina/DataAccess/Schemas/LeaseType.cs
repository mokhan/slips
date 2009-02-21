namespace Marina.DataAccess.Schemas {
	public static class LeaseType {
		public const string TableName = "LeaseType";
		public static readonly DatabaseColumn LeaseTypeID = new DatabaseColumn( TableName, "LeaseTypeID" );
		public static readonly DatabaseColumn LeaseTypeName = new DatabaseColumn( TableName, "LeaseTypeName" );
		public static readonly DatabaseColumn StandardRateAmount = new DatabaseColumn( TableName, "StandardRateAmount" );
	}
}