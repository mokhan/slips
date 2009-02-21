using System.Collections.Generic;
using Marina.DataAccess;
using Marina.DataAccess.DataMappers;
using Marina.Domain.Interfaces;
using Marina.Infrastructure;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.DataAccess.Mappers {
	[TestFixture]
	public class CustomerDataMapperTest {
		private MockRepository _mockery;
		private IDatabaseGateway _mockGateway;
		private IBoatDataMapper _boatMapper;
		private ILeaseDataMapper _leaseDataMapper;
		private IRegistrationDataMapper _registrationMapper;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_mockGateway = _mockery.DynamicMock< IDatabaseGateway >( );
			_boatMapper = _mockery.DynamicMock< IBoatDataMapper >( );
			_leaseDataMapper = _mockery.DynamicMock< ILeaseDataMapper >( );
			_registrationMapper = _mockery.DynamicMock< IRegistrationDataMapper >( );
		}

		public ICustomerDataMapper CreateSUT() {
			return new CustomerDataMapper( _mockGateway, _boatMapper, _leaseDataMapper, _registrationMapper );
		}

		[Test]
		public void Should_leverage_mapper_to_load_customers_boats() {
			long customerId = 32;

			IList< IBoat > boats = new List< IBoat >( );
			IBoat boat = _mockery.DynamicMock< IBoat >( );
			boats.Add( boat );

			using ( _mockery.Record( ) ) {
				Expect.Call( _boatMapper.AllBoatsFor( customerId ) ).Return( boats );
			}

			using ( _mockery.Playback( ) ) {
				ICustomer customer = CreateSUT( ).FindBy( customerId );
				Assert.AreEqual( 1, ListFactory.From( customer.RegisteredBoats( ) ).Count );
				Assert.IsTrue( ListFactory.From( customer.RegisteredBoats( ) ).Contains( boat ) );
			}
		}

		[Test]
		public void Should_leverage_mapper_to_load_customer_leases() {
			long customerId = 32;
			IList< ISlipLease > leases = new List< ISlipLease >( );
			ISlipLease lease = _mockery.DynamicMock< ISlipLease >( );
			leases.Add( lease );

			using ( _mockery.Record( ) ) {
				Expect
					.Call( _leaseDataMapper.AllLeasesFor( customerId ) )
					.Return( leases );
			}

			using ( _mockery.Playback( ) ) {
				ICustomer customer = CreateSUT( ).FindBy( customerId );
				Assert.AreEqual( 1, ListFactory.From( customer.Leases( ) ).Count );
				Assert.IsTrue( ListFactory.From( customer.Leases( ) ).Contains( lease ) );
			}
		}

		[Test]
		public void Should_leverage_mapper_to_load_customer_registration() {
			long customerId = 59;

			IRegistration registration = _mockery.DynamicMock< IRegistration >( );

			using ( _mockery.Record( ) ) {
				Expect.Call( _registrationMapper.For( customerId ) ).Return( registration );
			}

			using ( _mockery.Playback( ) ) {
				ICustomer customer = CreateSUT( ).FindBy( customerId );
				Assert.AreEqual( registration, customer.Registration( ) );
			}
		}
	}
}