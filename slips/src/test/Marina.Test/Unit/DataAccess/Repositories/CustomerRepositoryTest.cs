using Marina.DataAccess;
using Marina.DataAccess.DataMappers;
using Marina.DataAccess.Repositories;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.DataAccess.Repositories {
	[TestFixture]
	public class CustomerRepositoryTest {
		private MockRepository _mockery;
		private IIdentityMap< ICustomer > _mockIdentityMap;
		private ICustomerDataMapper _mockMapper;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_mockIdentityMap = _mockery.DynamicMock< IIdentityMap< ICustomer > >( );
			_mockMapper = _mockery.DynamicMock< ICustomerDataMapper >( );
		}

		public ICustomerRepository CreateSUT() {
			return CreateSUT( _mockIdentityMap, _mockMapper );
		}

		private ICustomerRepository CreateSUT( IIdentityMap< ICustomer > identityMap, ICustomerDataMapper mapper ) {
			return new CustomerRepository( identityMap, mapper );
		}

		[Test]
		public void Should_check_identity_map_to_see_if_customer_is_loaded() {
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			long customerId = 23455;

			using ( _mockery.Record( ) ) {
				Expect.Call( _mockIdentityMap.ContainsObjectWithIdOf( customerId ) ).Return( true );
				Expect.Call( _mockIdentityMap.FindObjectWithIdOf( customerId ) ).Return( customer );
			}

			using ( _mockery.Playback( ) ) {
				Assert.AreEqual( customer, CreateSUT( ).FindBy( customerId ) );
			}
		}

		[Test]
		public void Should_leverage_mapper_to_load_customer_if_not_in_identity_map() {
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			long customerId = 23455;

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockIdentityMap.ContainsObjectWithIdOf( customerId ) ).Return( false );
				Expect.Call( _mockMapper.FindBy( customerId ) ).Return( customer );
			}

			using ( _mockery.Playback( ) ) {
				Assert.AreEqual( customer, CreateSUT( ).FindBy( customerId ) );
			}
		}

		[Test]
		public void Should_add_customer_to_identity_map_after_retrieving_from_mapper() {
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			long customerId = 23455;

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockIdentityMap.ContainsObjectWithIdOf( customerId ) ).Return( false );
				SetupResult.For( _mockMapper.FindBy( customerId ) ).Return( customer );
				_mockIdentityMap.Add( customer );
			}

			using ( _mockery.Playback( ) ) {
				Assert.AreEqual( customer, CreateSUT( ).FindBy( customerId ) );
			}
		}

		[Test]
		public void Should_create_a_new_customer() {
			using ( _mockery.Record( ) ) {}

			using ( _mockery.Playback( ) ) {
				ICustomer newCustomer = CreateSUT( ).NewCustomer( );
				Assert.AreEqual( -1, newCustomer.ID( ) );
			}
		}

		[Test]
		public void Should_leverage_mapper_to_insert_new_customer() {
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			long customerId = 34;

			using ( _mockery.Record( ) ) {
				SetupResult.For( customer.ID( ) ).Return( customerId );
				SetupResult.For( _mockIdentityMap.ContainsObjectWithIdOf( customerId ) ).Return( false );

				_mockMapper.Insert( customer );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Save( customer );
			}
		}

		[Test]
		public void Should_add_new_customer_to_identity_map_after_insert() {
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			long customerId = 34;

			using ( _mockery.Record( ) ) {
				SetupResult.For( customer.ID( ) ).Return( customerId );
				SetupResult.For( _mockIdentityMap.ContainsObjectWithIdOf( customerId ) ).Return( false );
				using ( _mockery.Ordered( ) ) {
					_mockMapper.Insert( customer );
					_mockIdentityMap.Add( customer );
				}
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).Save( customer );
			}
		}

		[Test]
		public void Should_leverage_mapper_to_update_customer() {
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			IIdentityMap< ICustomer > identityMap = _mockery.CreateMock< IIdentityMap< ICustomer > >( );
			ICustomerDataMapper dataMapper = _mockery.CreateMock< ICustomerDataMapper >( );
			long customerId = 46;

			using ( _mockery.Record( ) ) {
				SetupResult.For( customer.ID( ) ).Return( customerId );
				SetupResult.For( identityMap.ContainsObjectWithIdOf( customerId ) ).Return( true );

				dataMapper.Update( customer );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( identityMap, dataMapper ).Save( customer );
			}
		}
	}
}