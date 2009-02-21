using Marina.Domain;
using Marina.Domain.Exceptions;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using Marina.Infrastructure;
using Marina.Presentation.DTO;
using Marina.Task;
using Marina.Task.Mappers;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Marina.Test.Unit.Task {
	[TestFixture]
	public class LeaseTasksTest {
		private MockRepository _mockery;
		private ICustomerRepository _customers;
		private ILeaseToDtoMapper _mapper;
		private ISlipsRepository _slips;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_customers = _mockery.DynamicMock< ICustomerRepository >( );
			_slips = _mockery.DynamicMock< ISlipsRepository >( );
			_mapper = _mockery.DynamicMock< ILeaseToDtoMapper >( );
		}

		public ILeaseTasks CreateSUT() {
			return new LeaseTasks( _customers, _slips, _mapper );
		}

		[Test]
		public void Should_leverage_repository_to_find_customer() {
			long customerId = 87;

			using ( _mockery.Record( ) ) {
				Expect.Call( _customers.FindBy( customerId ) ).Return( _mockery.DynamicMock< ICustomer >( ) );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).FindAllLeasesFor( customerId );
			}
		}

		[Test]
		public void Should_leverage_mapper_to_convert_to_dto() {
			long customerId = 99;
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			ISlipLease lease = _mockery.DynamicMock< ISlipLease >( );
			DisplayLeaseDTO dto = new DisplayLeaseDTO( "", "", "" );

			using ( _mockery.Record( ) ) {
				SetupResult.For( customer.Leases( ) ).Return( ListFactory.For( lease ) );
				SetupResult.For( _customers.FindBy( customerId ) ).Return( customer );
				Expect.Call( _mapper.MapFrom( lease ) ).Return( dto );
			}

			using ( _mockery.Playback( ) ) {
				IRichList< DisplayLeaseDTO > returnedDtos = ListFactory.From( CreateSUT( ).FindAllLeasesFor( customerId ) );
				Assert.AreEqual( 1, returnedDtos.Count );
				Assert.IsTrue( returnedDtos.Contains( dto ) );
			}
		}

		[Test]
		public void Should_lookup_customer_from_repository_when_requesting_a_lease() {
			long customerId = 87;
			long slipId = 32;
			SubmitLeaseRequestDTO request = new SubmitLeaseRequestDTO( customerId, slipId, "daily" );
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );

			using ( _mockery.Record( ) ) {
				Expect.Call( _customers.FindBy( customerId ) ).Return( customer );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).RequestLeaseUsing( request );
			}
		}

		[RowTest]
		[Row( 99 )]
		[Row( 87 )]
		public void Should_lookup_slip_from_repository_when_requesting_a_lease( long slipId ) {
			long customerId = 87;
			SubmitLeaseRequestDTO request = new SubmitLeaseRequestDTO( customerId, slipId, "weekly" );
			ISlip slip = _mockery.DynamicMock< ISlip >( );
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _customers.FindBy( 0 ) ).IgnoreArguments( ).Return( customer );
				Expect.Call( _slips.FindBy( slipId ) ).Return( slip );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).RequestLeaseUsing( request );
			}
		}

		[Test]
		public void customer_should_attempt_to_lease_slip() {
			long customerId = 87;
			long slipId = 32;

			string duration = "weekly";
			SubmitLeaseRequestDTO request = new SubmitLeaseRequestDTO( customerId, slipId, duration );
			ISlip slip = _mockery.DynamicMock< ISlip >( );
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _customers.FindBy( customerId ) ).Return( customer );
				SetupResult.For( _slips.FindBy( slipId ) ).Return( slip );

				customer.Lease( slip, LeaseDurations.FindBy( duration ) );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).RequestLeaseUsing( request );
			}
		}

		[Test]
		public void should_return_success_response_message() {
			long customerId = 87;
			long slipId = 32;

			string duration = LeaseDurations.Daily.Name( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _customers.FindBy( customerId ) ).Return( _mockery.DynamicMock< ICustomer >( ) );
			}

			using ( _mockery.Playback( ) ) {
				DisplayResponseLineDTO response =
					CreateSUT( ).RequestLeaseUsing( new SubmitLeaseRequestDTO( customerId, slipId, duration ) );
				Assert.AreEqual( response.Message, "Success!" );
			}
		}

		[Test]
		public void Should_return_error_message_if_the_slip_is_already_leased() {
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			using ( _mockery.Record( ) ) {
				SetupResult
					.For( _customers.FindBy( 0 ) )
					.IgnoreArguments( )
					.Return( customer );

				customer.Lease( null, null );
				LastCall
					.IgnoreArguments( )
					.Throw( new SlipIsAlreadyLeasedException( ) );
			}

			using ( _mockery.Playback( ) ) {
				SubmitLeaseRequestDTO request = new SubmitLeaseRequestDTO( 1, 2, "weekly" );
				DisplayResponseLineDTO response = CreateSUT( ).RequestLeaseUsing( request );
				Assert.AreEqual( "Slip is already leased!", response.Message );
			}
		}

		[Test]
		public void Should_save_customer_back_to_repository() {
			long customerId = 87;
			long slipId = 32;

			ICustomer customer = _mockery.DynamicMock< ICustomer >( );

			using ( _mockery.Record( ) ) {
				SetupResult
					.For( _customers.FindBy( customerId ) )
					.Return( customer );
				_customers.Save( customer );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).RequestLeaseUsing( new SubmitLeaseRequestDTO( customerId, slipId, LeaseDurations.Daily.Name( ) ) );
			}
		}
	}
}