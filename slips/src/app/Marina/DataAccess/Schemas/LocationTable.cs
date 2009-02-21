namespace Marina.DataAccess.Schemas {
	public class LocationTable {
		public const string TableName = "Location";
		public static readonly DatabaseColumn ID = new DatabaseColumn( TableName, "LocationId" );
		public static readonly DatabaseColumn Name = new DatabaseColumn( TableName, "LocationName" );
	}
}