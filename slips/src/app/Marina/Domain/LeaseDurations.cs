using System;
using System.Collections.Generic;
using Marina.Domain.Interfaces;

namespace Marina.Domain {
	public class LeaseDurations {
		public static readonly ILeaseDuration Daily = new LeaseDuration( "Daily", 1, 1 );
		public static readonly ILeaseDuration Weekly = new LeaseDuration( "Weekly", 2, 7 );
		public static readonly ILeaseDuration Monthly = new LeaseDuration( "Monthly", 3, 30 );
		public static readonly ILeaseDuration Yearly = new LeaseDuration( "Yearly", 4, 365 );
		private static readonly ILeaseDuration NoDuration = new LeaseDuration( "No Duration", -1, 0 );
		private static readonly ILeaseDuration UnknownDuration = new LeaseDuration( "Unknown", -1, 0 );

		private class LeaseDuration : DomainObject, ILeaseDuration {
			private readonly int _days;
			private readonly string _name;

			public LeaseDuration( string name, long id, int days ) : base( id ) {
				_days = days;
				_name = name;
			}

			public DateTime CalculateExpiryDateFrom( DateTime startDate ) {
				return startDate.AddDays( _days ).Date.AddHours( 11 );
			}

			public string Name() {
				return _name;
			}

			public bool IsSatisfiedBy( IDateRange range ) {
				TimeSpan daysInRange = range.End( ).Subtract( range.Start( ) );
				return _days <= daysInRange.Days;
			}
		}

		public static ILeaseDuration FindFor( DateTime startDate, DateTime endDate ) {
			foreach ( ILeaseDuration duration in AllDurations( ) ) {
				if ( duration.IsSatisfiedBy( new DateRange( startDate, endDate ) ) ) {
					return duration;
				}
			}
			return NoDuration;
		}

		private static IEnumerable< ILeaseDuration > AllDurations() {
			yield return Yearly;
			yield return Monthly;
			yield return Weekly;
			yield return Daily;
		}

		public static ILeaseDuration FindBy( string duration ) {
			foreach ( ILeaseDuration leaseDuration in AllDurations( ) ) {
				if ( string.Compare( leaseDuration.Name( ), duration, true ) == 0 ) {
					return leaseDuration;
				}
			}
			return UnknownDuration;
		}
	}
}