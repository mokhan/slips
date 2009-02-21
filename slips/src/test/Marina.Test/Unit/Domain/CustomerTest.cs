using System;
using Marina.Domain;
using Marina.Domain.Exceptions;
using Marina.Domain.Interfaces;
using Marina.Infrastructure;
using Marina.Test.Utility;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Domain {
	[TestFixture]
	public class CustomerTest {
		private MockRepository _mockery;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
		}

		public ICustomer CreateSUT() {
			return new Customer( );
		}

		[Test]
		public void Should_be_able_to_register_a_new_boat() {
			ICustomer customer = CreateSUT( );

			Assert.AreEqual( 0, ListFactory.From( customer.RegisteredBoats( ) ).Count );
			customer.RegisterBoat( ObjectMother.Boat( ) );
			Assert.AreEqual( 1, ListFactory.From( customer.RegisteredBoats( ) ).Count );
		}

		[Test]
		public void Should_not_be_able_to_register_an_already_registered_boat() {
			ICustomer customer = CreateSUT( );
			IBoat boat = ObjectMother.Boat( );
			customer.RegisterBoat( boat );
			customer.RegisterBoat( boat );

			Assert.AreEqual( 1, ListFactory.From( customer.RegisteredBoats( ) ).Count );
		}

		[Test]
		public void Should_be_able_to_lease_a_slip() {
			ICustomer customer = CreateSUT( );
			ISlip slip = ObjectMother.Slip( );
			ILeaseDuration duration = LeaseDurations.Monthly;

			customer.Lease( slip, duration );

			Assert.AreEqual( 1, ListFactory.From( customer.Leases( ) ).Count );
		}

		[Test]
		[ExpectedException( typeof( SlipIsAlreadyLeasedException ) )]
		public void Should_not_be_able_to_lease_a_slip_that_is_already_leased() {
			ISlip slip = _mockery.DynamicMock< ISlip >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( slip.IsLeased( ) ).Return( true );
			}

			using ( _mockery.Playback( ) ) {
				ICustomer customer = CreateSUT( );
				customer.Lease( slip, LeaseDurations.Yearly );
				Assert.AreEqual( 0, ListFactory.From( customer.Leases( ) ).Count );
			}
		}

		[Test]
		public void Should_be_able_to_register_an_unregistered_boat() {
			string registrationNumber = "435535";
			string manufacturer = "YAMAHA";
			DateTime yearOfModel = new DateTime( 1990, 01, 01 );
			long lengthInFeet = 100;

			ICustomer customer = CreateSUT( );
			customer.RegisterBoat( registrationNumber, manufacturer, yearOfModel, lengthInFeet );

			IRichList< IBoat > boats = ListFactory.From( customer.RegisteredBoats( ) );

			Assert.AreEqual( 1, boats.Count );
			Assert.AreEqual( registrationNumber, boats[ 0 ].RegistrationNumber( ) );
			Assert.AreEqual( manufacturer, boats[ 0 ].Manufacturer( ) );
			Assert.AreEqual( yearOfModel, boats[ 0 ].YearOfModel( ) );
			Assert.AreEqual( lengthInFeet, boats[ 0 ].LengthInFeet( ) );
		}

		[Test]
		public void Should_be_able_to_register_an_account() {
			ICustomer customer = CreateSUT( );
			customer.RegisterAccount( "username", "password", "mo", "khan", "4036813389", "calgary" );
			IRegistration registration = customer.Registration( );

			Assert.AreEqual( "username", registration.Username( ) );
			Assert.AreEqual( "password", registration.Password( ) );
			Assert.AreEqual( "mo", registration.FirstName( ) );
			Assert.AreEqual( "khan", registration.LastName( ) );
			Assert.AreEqual( "4036813389", registration.PhoneNumber( ) );
			Assert.AreEqual( "calgary", registration.City( ) );
		}

		[Test]
		public void should_have_no_registration_information() {
			IRegistration registration = CreateSUT( ).Registration( );
			Assert.AreEqual( "", registration.Username( ) );
			Assert.AreEqual( "", registration.Password( ) );
		}

		[Test]
		public void Should_be_able_to_update_the_registration_information() {
			IRegistration registration = _mockery.DynamicMock< IRegistration >( );
			ICustomer customer = CreateSUT( );
			customer.UpdateRegistrationTo( registration );
			Assert.AreEqual( registration, customer.Registration( ) );
		}
	}
}