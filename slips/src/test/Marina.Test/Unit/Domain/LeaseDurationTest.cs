using System;
using Marina.Domain;
using Marina.Domain.Interfaces;
using MbUnit.Framework;

namespace Marina.Test.Unit.Domain {
	[TestFixture]
	public class LeaseDurationTest {
		[Test]
		public void Should_return_daily_lease_duration() {
			DateTime yesterday = DateTime.Now.AddDays( -1 );
			DateTime today = DateTime.Now;

			ILeaseDuration duration = LeaseDurations.FindFor( yesterday, today );
			Assert.AreEqual( LeaseDurations.Daily, duration );
		}

		[Test]
		public void Should_return_weekly_lease_duration() {
			DateTime aWeekAgo = DateTime.Now.AddDays( -7 ).Date;
			DateTime today = DateTime.Now.Date;

			ILeaseDuration duration = LeaseDurations.FindFor( aWeekAgo, today );
			Assert.AreEqual( LeaseDurations.Weekly, duration );
		}

		[Test]
		public void Should_return_monthly_lease_duration() {
			DateTime aMonthAgo = DateTime.Now.AddDays( -30 );
			DateTime today = DateTime.Now;

			ILeaseDuration duration = LeaseDurations.FindFor( aMonthAgo, today );
			Assert.AreEqual( LeaseDurations.Monthly, duration );
		}

		[Test]
		public void Should_return_yearly_lease_duration() {
			DateTime aYearAgo = DateTime.Now.AddDays( -365 );
			DateTime today = DateTime.Now;

			ILeaseDuration duration = LeaseDurations.FindFor( aYearAgo, today );
			Assert.AreEqual( LeaseDurations.Yearly, duration );
		}
	}
}