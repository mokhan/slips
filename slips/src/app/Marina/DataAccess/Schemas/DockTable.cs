namespace Marina.DataAccess.Schemas {
	public static class DockTable {
		public const string TableName = "Dock";
		public static readonly DatabaseColumn DockID = new DatabaseColumn( TableName, "DockID" );
		public static readonly DatabaseColumn DockName = new DatabaseColumn( TableName, "DockName" );
		public static readonly DatabaseColumn LocationId = new DatabaseColumn( TableName, "LocationId" );
		public static readonly DatabaseColumn WaterService = new DatabaseColumn( TableName, "WaterService" );
		public static readonly DatabaseColumn ElectricalService = new DatabaseColumn( TableName, "ElectricalService" );
	}
}