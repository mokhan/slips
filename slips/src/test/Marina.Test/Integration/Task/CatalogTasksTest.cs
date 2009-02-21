using Marina.Infrastructure;
using Marina.Task;
using Marina.Test.Utility;
using MbUnit.Framework;

namespace Marina.Test.Integration.Task {
	[TestFixture]
	public class CatalogTasksTest {
		public ICatalogTasks CreateSUT() {
			return new CatalogTasks( );
		}

		[RunInRealContainer]
		[Test]
		public void Should_return_at_least_one_available_slip() {
			Assert.IsTrue( ListFactory.From( CreateSUT( ).GetAllAvailableSlips( ) ).Count > 0 );
		}
	}
}