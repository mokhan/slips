using System.Collections.Generic;
using Marina.DataAccess.DataMappers;
using Marina.DataAccess.Repositories;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using Marina.Infrastructure;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.DataAccess.Repositories {
	[TestFixture]
	public class SlipRepositoryTest {
		private MockRepository _mockery;
		private ISlipDataMapper _mockMapper;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_mockMapper = _mockery.DynamicMock< ISlipDataMapper >( );
		}

		public ISlipsRepository CreateSUT() {
			return new SlipsRepository( _mockMapper );
		}

		[Test]
		public void Should_leverage_mapper_to_convert_from_table_to_a_domain_object() {
			ISlip unleasedSlip = _mockery.DynamicMock< ISlip >( );
			ISlip leasedSlip = _mockery.DynamicMock< ISlip >( );

			IList< ISlip > slips = new List< ISlip >( );
			slips.Add( unleasedSlip );
			slips.Add( leasedSlip );

			using ( _mockery.Record( ) ) {
				SetupResult.For( unleasedSlip.IsLeased( ) ).Return( false );
				SetupResult.For( leasedSlip.IsLeased( ) ).Return( true );

				Expect.Call( _mockMapper.AllSlips( ) ).Return( new RichEnumerable< ISlip >( slips ) );
			}

			using ( _mockery.Playback( ) ) {
				IRichList< ISlip > foundSlips = ListFactory.From( CreateSUT( ).AllAvailableSlips( ) );

				Assert.IsTrue( foundSlips.Contains( unleasedSlip ) );
				Assert.IsFalse( foundSlips.Contains( leasedSlip ) );
			}
		}
	}
}