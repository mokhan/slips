using System;
using System.Collections.Generic;
using Marina.DataAccess.Builders;
using Marina.DataAccess.Schemas;
using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Infrastructure.Container;

namespace Marina.DataAccess.DataMappers {
	public class LeaseDataMapper : ILeaseDataMapper {
		public LeaseDataMapper()
			: this( Resolve.DependencyFor< IDatabaseGateway >( ), Resolve.DependencyFor< ISlipDataMapper >( ) ) {}

		public LeaseDataMapper( IDatabaseGateway gateway, ISlipDataMapper slipMapper ) {
			_gateway = gateway;
			_slipMapper = slipMapper;
		}

		public IEnumerable< ISlipLease > AllLeasesFor( long customerId ) {
			foreach ( IDatabaseRow row in _gateway.FindAllRowsMatching( Queries.SelectLeasesFor( customerId ) ) ) {
				yield return
					new SlipLease(
						_slipMapper.FindBy( row.From< long >( LeaseTable.SlipID ) ),
						LeaseDurations.FindFor( row.From< DateTime >( LeaseTable.StartDate ), row.From< DateTime >( LeaseTable.EndDate ) ),
						row.From< DateTime >( LeaseTable.StartDate ),
						row.From< DateTime >( LeaseTable.EndDate )
						);
			}
		}

		public void Insert( IEnumerable< ISlipLease > leases, long forCustomerId ) {
			using ( IDatabaseTransaction transaction = new DatabaseTransaction( ) ) {
				IList< IQuery > queries = new List< IQuery >( );
				foreach ( ISlipLease lease in leases ) {
					queries.Add(
						DatabaseInsert.Into( LeaseTable.TableName )
							.AddValue( LeaseTable.StartDate, lease.StartDate( ) )
							.AddValue( LeaseTable.EndDate, lease.ExpiryDate( ) )
							.AddValue( LeaseTable.SlipID, lease.Slip( ).ID( ) )
							.AddValue( LeaseTable.CustomerID, forCustomerId )
							.AddValue( LeaseTable.LeaseTypeID, lease.Duration( ).ID( ) ).Build( )
						);
				}
				_gateway.Execute( queries );
				transaction.Commit( );
			}
		}

		public void Update( IEnumerable< ISlipLease > leases, long forCustomerId ) {
			using ( IDatabaseTransaction transaction = new DatabaseTransaction( ) ) {
				_gateway.Execute( DatabaseDelete.Where( LeaseTable.CustomerID, forCustomerId ) );
				Insert( leases, forCustomerId );
				transaction.Commit( );
			}
		}

		public bool IsLeased( long slipId ) {
			IQuery query =
				DatabaseSelect.From( LeaseTable.TableName ).AddColumn( LeaseTable.SlipID ).Where( LeaseTable.SlipID, slipId ).Build( );

			return !_gateway.LoadRowUsing( query ).Equals( DatabaseRow.Blank );
		}

		private readonly IDatabaseGateway _gateway;
		private readonly ISlipDataMapper _slipMapper;

		private static class Queries {
			public static IQuery SelectLeasesFor( long customerId ) {
				return DatabaseSelect
					.From( LeaseTable.TableName )
					.AddColumn( LeaseTable.EndDate )
					.AddColumn( LeaseTable.ID )
					.AddColumn( LeaseTable.LeaseTypeID )
					.AddColumn( LeaseTable.SlipID )
					.AddColumn( LeaseTable.StartDate )
					.Where( LeaseTable.CustomerID, customerId ).Build( );
			}

			public static IQuery SelectLeaseFor( long slipId ) {
				return DatabaseSelect.From( LeaseTable.TableName )
					.AddColumn( LeaseTable.StartDate )
					.AddColumn( LeaseTable.EndDate )
					.Where( LeaseTable.SlipID, slipId ).Build( );
			}
		}
	}
}