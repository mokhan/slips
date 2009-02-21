using System.Collections.Generic;
using Marina.DataAccess.Builders;
using Marina.DataAccess.Schemas;
using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Infrastructure;
using Marina.Infrastructure.Container;

namespace Marina.DataAccess.DataMappers {
	public class SlipDataMapper : ISlipDataMapper {
		public SlipDataMapper( IDatabaseGateway gateway ) {
			_gateway = gateway;
		}

		public ISlip FindBy( long slipId ) {
			return Map.From( _gateway.LoadRowUsing( Queries.SelectSlipBy( slipId ) ) );
		}

		public IRichEnumerable< ISlip > AllSlips() {
			return new RichEnumerable< ISlip >( FetchAllSlips( ) );
		}

		private IEnumerable< ISlip > FetchAllSlips() {
			return Map.From( _gateway.FindAllRowsMatching( Queries.SelectAllSlips( ) ) );
		}

		private readonly IDatabaseGateway _gateway;

		private static class Queries {
			public static IQuery SelectAllSlips() {
				return SelectAllColumns( ).Build( );
			}

			public static IQuery SelectSlipBy( long slipId ) {
				return SelectAllColumns( ).Where( SlipTable.ID, slipId ).Build( );
			}

			private static ISelectQueryBuilder SelectAllColumns() {
				return DatabaseSelect
					.From( SlipTable.TableName )
					.AddColumn( SlipTable.ID )
					.AddColumn( SlipTable.Width )
					.AddColumn( SlipTable.Length )
					.AddColumn( SlipTable.DockID )
					.AddColumn( DockTable.DockName )
					.AddColumn( DockTable.WaterService )
					.AddColumn( DockTable.ElectricalService )
					.AddColumn( LocationTable.Name )
					.InnerJoinOn( DockTable.DockID, SlipTable.DockID )
					.InnerJoinOn( LocationTable.ID, DockTable.LocationId );
			}
		}

		private static class Map {
			public static IEnumerable< ISlip > From( IEnumerable< IDatabaseRow > rows ) {
				return new EnumerableMapper< IDatabaseRow, ISlip >( new DatabaseRowToSlipMapper( ) ).MapFrom( rows );
			}

			public static ISlip From( IDatabaseRow row ) {
				return new DatabaseRowToSlipMapper( ).MapFrom( row );
			}

			private class DatabaseRowToSlipMapper : IMapper< IDatabaseRow, ISlip > {
				public DatabaseRowToSlipMapper()
					: this( Resolve.DependencyFor< ILeaseDataMapper >( ) ) {}

				public DatabaseRowToSlipMapper( ILeaseDataMapper leaseDataMapper ) {
					this.leaseDataMapper = leaseDataMapper;
				}

				public ISlip MapFrom( IDatabaseRow row ) {
					return new Slip(
						row.From< long >( SlipTable.ID ),
						CreateDockFrom( row ),
						row.From< int >( SlipTable.Width ),
						row.From< int >( SlipTable.Length ),
						leaseDataMapper.IsLeased( row.From< long >( SlipTable.ID ) )
						);
				}

				private static Dock CreateDockFrom( IDatabaseRow row ) {
					return new Dock(
						row.From< long >( DockTable.DockID ),
						row.From< string >( DockTable.DockName ),
						new Location( row.From< string >( LocationTable.Name ) ),
						Utilities.For(
							row.From< bool >( DockTable.WaterService ) ? Utilities.Water : null,
							row.From< bool >( DockTable.ElectricalService ) ? Utilities.Electrical : null
							)
						);
				}

				private readonly ILeaseDataMapper leaseDataMapper;
			}
		}
	}
}