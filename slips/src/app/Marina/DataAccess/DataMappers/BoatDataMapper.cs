using System;
using System.Collections.Generic;
using Marina.DataAccess.Builders;
using Marina.DataAccess.Schemas;
using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Infrastructure.Container;

namespace Marina.DataAccess.DataMappers {
	public class BoatDataMapper : IBoatDataMapper {
		public BoatDataMapper() : this( Resolve.DependencyFor< IDatabaseGateway >( ) ) {}

		public BoatDataMapper( IDatabaseGateway gateway ) {
			_gateway = gateway;
		}

		public IEnumerable< IBoat > AllBoatsFor( long customerId ) {
			return Map.From( _gateway.FindAllRowsMatching( Queries.SelectBoatsFor( customerId ) ) );
		}

		public void Insert( IEnumerable< IBoat > boats, long forCustomerId ) {
			_gateway.Execute( Queries.InsertQueriesFor( boats, forCustomerId ) );
		}

		public void Update( IEnumerable< IBoat > boats, long forCustomerId ) {
			using ( IDatabaseTransaction transaction = new DatabaseTransaction( ) ) {
				_gateway.Execute( DatabaseDelete.Where( BoatTable.CustomerID, forCustomerId ) );
				Insert( boats, forCustomerId );
				transaction.Commit( );
			}
		}

		private readonly IDatabaseGateway _gateway;

		private class Queries {
			public static IQuery SelectBoatsFor( long customerId ) {
				return DatabaseSelect.From( BoatTable.TableName )
					.AddColumn( BoatTable.Length )
					.AddColumn( BoatTable.Manufacturer )
					.AddColumn( BoatTable.ModelYear )
					.AddColumn( BoatTable.RegistrationNumber )
					.AddColumn( BoatTable.BoatID )
					.Where( BoatTable.CustomerID, customerId.ToString( ) ).Build( );
			}

			public static IEnumerable< IQuery > InsertQueriesFor( IEnumerable< IBoat > boats, long customerId ) {
				foreach ( IBoat boat in boats ) {
					yield return DatabaseInsert.Into( BoatTable.TableName )
						.AddValue( BoatTable.CustomerID, customerId )
						.AddValue( BoatTable.Length, boat.LengthInFeet( ) )
						.AddValue( BoatTable.Manufacturer, boat.Manufacturer( ) )
						.AddValue( BoatTable.ModelYear, boat.YearOfModel( ).Year )
						.AddValue( BoatTable.RegistrationNumber, boat.RegistrationNumber( ) ).Build( );
				}
			}
		}

		private class Map {
			public static IEnumerable< IBoat > From( IEnumerable< IDatabaseRow > rows ) {
				foreach ( IDatabaseRow dataRow in rows ) {
					yield return new Boat(
						dataRow.From< long >( BoatTable.BoatID ),
						dataRow.From< string >( BoatTable.RegistrationNumber ),
						dataRow.From< string >( BoatTable.Manufacturer ),
						dataRow.From< int >( BoatTable.ModelYear ) != 0
							? new DateTime( dataRow.From< int >( BoatTable.ModelYear ), 1, 01 )
							: DateTime.MinValue,
						dataRow.From< long >( BoatTable.Length )
						);
				}
			}
		}
	}
}