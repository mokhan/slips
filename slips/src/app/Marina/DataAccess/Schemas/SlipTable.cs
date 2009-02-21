namespace Marina.DataAccess.Schemas {
	public static class SlipTable {
		public const string TableName = "Slip";
		public static readonly DatabaseColumn ID = new DatabaseColumn( TableName, "SlipID" );
		public static readonly DatabaseColumn Width = new DatabaseColumn( TableName, "SlipWidth" );
		public static readonly DatabaseColumn Length = new DatabaseColumn( TableName, "SlipLength" );
		public static readonly DatabaseColumn DockID = new DatabaseColumn( TableName, "DockID" );
	}
}