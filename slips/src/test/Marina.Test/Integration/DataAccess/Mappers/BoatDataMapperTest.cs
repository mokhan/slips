using System;
using System.Collections.Generic;
using Marina.DataAccess.DataMappers;
using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Infrastructure;
using Marina.Test.Integration.DataAccess.Utility;
using Marina.Test.Utility;
using MbUnit.Framework;

namespace Marina.Test.Integration.DataAccess.Mappers {
	[TestFixture]
	public class BoatDataMapperTest {
		public IBoatDataMapper CreateSUT() {
			return new BoatDataMapper( );
		}

		[Test]
		[RunInRealContainer]
		[RollBack]
		public void Should_return_3_boats() {
			long customerId = CustomerMother.CreateCustomerRecord( );

			BoatMother.AddBoatsFor( customerId );

			IRichList< IBoat > boats = ListFactory.From( CreateSUT( ).AllBoatsFor( customerId ) );
			Assert.AreEqual( 3, boats.Count );
		}

		[Test]
		[RunInRealContainer]
		[RollBack]
		public void Should_be_able_to_insert_new_boats_for_customer() {
			IBoat firstBoat = new Boat( "reg1", "TOYOTA", new DateTime( 2001, 1, 1 ), 100 );
			IBoat secondBoat = new Boat( "reg2", "YAMAHA", new DateTime( 2005, 1, 1 ), 200 );

			IList< IBoat > boats = new List< IBoat >( );
			boats.Add( firstBoat );
			boats.Add( secondBoat );

			long customerId = CustomerMother.CreateCustomerRecord( );
			IBoatDataMapper mapper = CreateSUT( );
			mapper.Insert( boats, customerId );

			IRichList< IBoat > insertedBoats = ListFactory.From( mapper.AllBoatsFor( customerId ) );
			Assert.AreEqual( 2, insertedBoats.Count );
			Assert.IsTrue( insertedBoats.Contains( firstBoat ) );
			Assert.IsTrue( insertedBoats.Contains( secondBoat ) );
		}

		[Test]
		[RollBack]
		[RunInRealContainer]
		public void Should_insert_new_boats_for_customer() {
			long customerId = CustomerMother.CreateCustomerRecord( );
			IList< IBoat > boats = CreateBoats( );

			IBoatDataMapper mapper = CreateSUT( );
			mapper.Insert( boats, customerId );

			IBoat thirdBoat = new Boat( "reg3", "HONDA", new DateTime( 1999, 1, 1 ), 300 );
			boats.Add( thirdBoat );

			mapper.Update( boats, customerId );

			IRichList< IBoat > insertedBoats = ListFactory.From( mapper.AllBoatsFor( customerId ) );
			Assert.AreEqual( 3, insertedBoats.Count );
			Assert.IsTrue( insertedBoats.Contains( thirdBoat ) );
		}

		private IList< IBoat > CreateBoats() {
			IList< IBoat > boats = new List< IBoat >( );
			boats.Add( new Boat( "reg1", "TOYOTA", new DateTime( 2001, 1, 1 ), 100 ) );
			boats.Add( new Boat( "reg2", "YAMAHA", new DateTime( 2005, 1, 1 ), 200 ) );
			return boats;
		}
	}
}