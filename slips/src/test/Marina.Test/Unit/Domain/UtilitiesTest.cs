using Marina.Domain;
using Marina.Domain.Interfaces;
using MbUnit.Framework;

namespace Marina.Test.Unit.Domain {
	[TestFixture]
	public class UtilitiesTest {
		[Test]
		public void Should_be_equal_to_a_single_utility() {
			IUtility utility = Utilities.For( Utilities.Electrical );
			Assert.IsTrue( utility.IsEnabled( Utilities.Electrical ) );
		}

		[Test]
		public void Should_be_equal_to_two_utilities() {
			IUtility utility = Utilities.For( Utilities.Electrical, Utilities.Water );

			Assert.IsTrue( utility.IsEnabled( Utilities.Electrical ) );
			Assert.IsTrue( utility.IsEnabled( Utilities.Water ) );
		}

		[Test]
		public void Should_not_be_equal_to_either_utilities() {
			IUtility utility = Utilities.For( null );

			Assert.IsFalse( utility.IsEnabled( Utilities.Electrical ) );
			Assert.IsFalse( utility.IsEnabled( Utilities.Water ) );
		}

		[Test]
		public void Should_have_water_enabled() {
			IUtility utility = Utilities.For( null, Utilities.Water );
			Assert.IsTrue( utility.IsEnabled( Utilities.Water ) );
		}
	}
}