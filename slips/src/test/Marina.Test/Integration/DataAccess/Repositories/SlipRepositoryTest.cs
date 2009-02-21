using Marina.DataAccess.Repositories;
using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using Marina.Infrastructure;
using Marina.Test.Utility;
using MbUnit.Framework;

namespace Marina.Test.Integration.DataAccess.Repositories {
	[TestFixture]
	public class SlipRepositoryTest {
		public ISlipsRepository CreateSUT() {
			return new SlipsRepository( );
		}

		[RunInRealContainer]
		[Test]
		public void Should_return_at_least_one_available_slip() {
			Assert.IsTrue( ListFactory.From( CreateSUT( ).AllAvailableSlips( ) ).Count > 0 );
		}

		[RunInRealContainer]
		[Test]
		public void Should_return_at_least_one_available_slip_for_the_dock() {
			ISlipsRepository repository = CreateSUT( );
			IDock dock = new Dock( 1, string.Empty, null, null );

			IRichList< ISlip > slipsFound = ListFactory.From( repository.AllAvailableSlipsFor( dock ) );
			Assert.IsTrue( slipsFound.Count > 0 );
		}
	}
}