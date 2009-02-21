using System;
using Marina.Domain;
using Marina.Domain.Exceptions;
using Marina.Domain.Interfaces;
using Marina.Test.Utility;
using MbUnit.Framework;

namespace Marina.Test.Unit.Domain {
	[TestFixture]
	public class SlipTest {
		public ISlip CreateSUT() {
			return new Slip( -1, ObjectMother.Dock( ), 100, 100, false );
		}

		[Test]
		public void Should_not_be_leased_to_anyone() {
			Assert.IsFalse( CreateSUT( ).IsLeased( ) );
		}

		//[Test]
		//public void Should_be_able_to_lease_to_a_customer()
		//{
		//    ICustomer customer = ObjectMother.Customer();
		//    ISlip slip = CreateSUT();
		//    ILeaseDuration durationOfLease = LeaseDurations.Daily;

		//    ISlipLease lease = slip.LeaseTo(customer, durationOfLease);

		//    Assert.AreEqual(customer, lease.Owner());
		//    Assert.AreEqual(slip, lease.Slip());
		//    Assert.AreEqual(durationOfLease, lease.Duration());
		//    Assert.AreEqual(DateTime.Now.Date, lease.StartDate());
		//}

		[Test]
		public void Lease_should_expire_at_11_am_the_following_day() {
			DateTime elevenAmTomorrow = DateTime.Now.AddDays( 1 ).Date.AddHours( 11 );
			ISlipLease lease = CreateSUT( ).LeaseTo( ObjectMother.Customer( ), LeaseDurations.Daily );
			Assert.AreEqual( elevenAmTomorrow, lease.ExpiryDate( ) );
		}

		[Test]
		public void Lease_should_expire_in_seven_days_on_the_eleventh_hour() {
			DateTime oneWeekFromToday = DateTime.Now.AddDays( 7 ).Date.AddHours( 11 );
			ISlipLease lease = CreateSUT( ).LeaseTo( ObjectMother.Customer( ), LeaseDurations.Weekly );
			Assert.AreEqual( oneWeekFromToday, lease.ExpiryDate( ) );
		}

		[Test]
		public void Lease_should_expire_in_thirty_days_on_the_eleventh_hour() {
			DateTime oneMonthFromToday = DateTime.Now.AddDays( 30 ).Date.AddHours( 11 );
			ISlipLease lease = CreateSUT( ).LeaseTo( ObjectMother.Customer( ), LeaseDurations.Monthly );
			Assert.AreEqual( oneMonthFromToday, lease.ExpiryDate( ) );
		}

		[Test]
		public void Lease_should_expire_in_365_days_on_the_eleventh_hour() {
			DateTime oneYearFromToday = DateTime.Now.AddDays( 365 ).Date.AddHours( 11 );
			ISlipLease lease = CreateSUT( ).LeaseTo( ObjectMother.Customer( ), LeaseDurations.Yearly );
			Assert.AreEqual( oneYearFromToday, lease.ExpiryDate( ) );
		}

		[Test]
		public void Should_be_leased_to_an_owner() {
			ISlip slip = CreateSUT( );
			slip.LeaseTo( ObjectMother.Customer( ), LeaseDurations.Yearly );
			Assert.IsTrue( slip.IsLeased( ), "Should be leased to an owner" );
		}

		[Test]
		[ExpectedException( typeof( SlipIsAlreadyLeasedException ) )]
		public void Should_return_current_lease_if_it_is_already_leased_to_a_customer() {
			ISlip slip = CreateSUT( );
			slip.LeaseTo( ObjectMother.Customer( ), LeaseDurations.Yearly );
			slip.LeaseTo( ObjectMother.Customer( ), LeaseDurations.Weekly );
		}
	}
}