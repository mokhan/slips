using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Test.Utility;
using MbUnit.Framework;

namespace Marina.Test.Unit.Domain {
	[TestFixture]
	public class DockTest {
		private static IDock CreateSUT( params IUtility[] utilities ) {
			return new Dock( 1, "dock a", ObjectMother.Location( ), Utilities.For( utilities ) );
		}

		[Test]
		public void Should_be_able_to_tell_if_a_utility_is_enabled_at_the_dock() {
			IDock dock = CreateSUT( Utilities.Water );
			Assert.IsTrue( dock.IsUtilityEnabled( Utilities.Water ) );
			Assert.IsFalse( dock.IsUtilityEnabled( Utilities.Electrical ) );

			dock = CreateSUT( Utilities.Water, Utilities.Electrical );
			Assert.IsTrue( dock.IsUtilityEnabled( Utilities.Water ) );
			Assert.IsTrue( dock.IsUtilityEnabled( Utilities.Electrical ) );
		}
	}
}