using Marina.DataAccess.Builders;
using Marina.DataAccess.Schemas;
using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Infrastructure.Container;

namespace Marina.DataAccess.DataMappers {
	public class DockDataMapper : IDockDataMapper {
		public DockDataMapper() : this( Resolve.DependencyFor< IDatabaseGateway >( ) ) {}

		public DockDataMapper( IDatabaseGateway gateway ) {
			_gateway = gateway;
		}

		public IDock FindBy( long dockId ) {
			return Map.From( _gateway.LoadRowUsing( Queries.SelectDockBy( dockId ) ) );
		}

		private readonly IDatabaseGateway _gateway;

		private static class Queries {
			public static IQuery SelectDockBy( long dockId ) {
				return DatabaseSelect
					.From( DockTable.TableName )
					.AddColumn( DockTable.DockID )
					.AddColumn( DockTable.DockName )
					.AddColumn( DockTable.LocationId )
					.AddColumn( DockTable.WaterService )
					.AddColumn( DockTable.ElectricalService )
					.AddColumn( LocationTable.Name )
					.InnerJoinOn( LocationTable.ID, DockTable.LocationId )
					.Where( DockTable.DockID, dockId ).Build( );
			}
		}

		private class Map {
			public static IDock From( IDatabaseRow row ) {
				return new Dock(
					row.From< long >( DockTable.DockID ),
					row.From< string >( DockTable.DockName ),
					new Location( row.From< string >( LocationTable.Name ) ),
					GetEnabledUtilities( row )
					);
			}

			private static IUtility GetEnabledUtilities( IDatabaseRow row ) {
				return Utilities.For(
					row.From< bool >( DockTable.WaterService ) ? Utilities.Water : null,
					row.From< bool >( DockTable.ElectricalService ) ? Utilities.Electrical : null
					);
			}
		}
	}
}