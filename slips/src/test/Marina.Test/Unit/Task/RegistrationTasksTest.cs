using System;
using System.Collections.Generic;
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
	public class RegistrationTasksTest {
		private MockRepository _mockery;
		private ICustomerRepository _mockCustomerRepository;
		private IBrokenRulesToDisplayItemMapper _mockMapper;

		[SetUp]
		public void Setup() {
			_mockery = new MockRepository( );
			_mockCustomerRepository = _mockery.DynamicMock< ICustomerRepository >( );
			_mockMapper = _mockery.DynamicMock< IBrokenRulesToDisplayItemMapper >( );
		}

		public IRegistrationTasks CreateSUT() {
			return new RegistrationTasks( _mockMapper, _mockCustomerRepository );
		}

		[Test]
		public void Should_leverage_repository_to_create_a_new_customer() {
			string username = "username";
			string password = "password";
			string firstName = "mo";
			string lastName = "khan";
			string phoneNumber = "4036813389";
			string city = "calgary";
			RegisterCustomerDTO customerDTO =
				new RegisterCustomerDTO( username, password, firstName, lastName, phoneNumber, city );

			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			IRegistration registration = _mockery.DynamicMock< IRegistration >( );
			using ( _mockery.Record( ) ) {
				SetupResult.For( customer.Registration( ) ).Return( registration );
				SetupResult.For( registration.IsValid( ) ).Return( true );

				Expect.Call( _mockCustomerRepository.NewCustomer( ) ).Return( customer );
				customer.RegisterAccount( username, password, firstName, lastName, phoneNumber, city );
			}

			using ( _mockery.Playback( ) ) {
				ListFactory.From( CreateSUT( ).RegisterNew( customerDTO ) );
			}
		}

		private RegisterCustomerDTO RegisterCustomerDTO() {
			string username = "username";
			string password = "password";
			string firstName = "mo";
			string lastName = "khan";
			string phoneNumber = "4036813389";
			string city = "calgary";
			return new RegisterCustomerDTO( username, password, firstName, lastName, phoneNumber, city );
		}

		[Test]
		public void Should_return_registration_messages() {
			IRegistration registration = _mockery.DynamicMock< IRegistration >( );
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );

			IList< DisplayResponseLineDTO > brokenRulesDtos = new List< DisplayResponseLineDTO >( );
			IList< IBrokenRule > brokenRules = new List< IBrokenRule >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockCustomerRepository.NewCustomer( ) ).Return( customer );
				SetupResult.For( customer.Registration( ) ).Return( registration );

				using ( _mockery.Ordered( ) ) {
					Expect.Call( registration.IsValid( ) ).Return( false );
					Expect.Call( registration.BrokenRules( ) ).Return( brokenRules );
					Expect.Call( _mockMapper.MapFrom( brokenRules ) ).Return( brokenRulesDtos );
				}
			}

			using ( _mockery.Playback( ) ) {
				Assert.AreEqual( brokenRulesDtos, CreateSUT( ).RegisterNew( RegisterCustomerDTO( ) ) );
			}
		}

		[Test]
		public void Should_return_a_success_message_if_there_are_no_broken_rules() {
			IRegistration registration = _mockery.CreateMock< IRegistration >( );

			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			using ( _mockery.Record( ) ) {
				Expect.Call( _mockCustomerRepository.NewCustomer( ) ).Return( customer );
				SetupResult.For( customer.Registration( ) ).Return( registration );
				Expect
					.Call( registration.IsValid( ) )
					.Return( true );
			}

			using ( _mockery.Playback( ) ) {
				IRichList< DisplayResponseLineDTO > lineItems =
					ListFactory.From( CreateSUT( ).RegisterNew( RegisterCustomerDTO( ) ) );
				Assert.IsTrue( lineItems.Contains( new DisplayResponseLineDTO( "Success!" ) ) );
			}
		}

		[Test]
		public void Should_lookup_customer_from_repository_using_customer_id() {
			int customerId = 1;
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			using ( _mockery.Record( ) ) {
				Expect.Call( _mockCustomerRepository.FindBy( customerId ) ).Return( customer );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).AddNewBoatUsing( new BoatRegistrationDTO( "reg#", "YAMAHA", "2007", "100", customerId ) );
			}
		}

		[Test]
		public void Should_register_boat_with_customer() {
			int customerId = 1;
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			using ( _mockery.Record( ) ) {
				SetupResult.For( _mockCustomerRepository.FindBy( customerId ) ).Return( customer );
				customer.RegisterBoat( "reg#", "YAMAHA", new DateTime( 2007, 01, 01 ), 100 );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).AddNewBoatUsing( new BoatRegistrationDTO( "reg#", "YAMAHA", "2007", "100", customerId ) );
			}
		}

		[Test]
		public void Should_save_the_changed_customer_to_the_repository() {
			int customerId = 1;
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			using ( _mockery.Record( ) ) {
				using ( _mockery.Ordered( ) ) {
					SetupResult.For( _mockCustomerRepository.FindBy( customerId ) ).Return( customer );
					customer.RegisterBoat( "reg#", "YAMAHA", new DateTime( 2007, 01, 01 ), 100 );
					_mockCustomerRepository.Save( customer );
				}
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).AddNewBoatUsing( new BoatRegistrationDTO( "reg#", "YAMAHA", "2007", "100", customerId ) );
			}
		}

		[Test]
		public void Should_leverage_repository_to_find_customer() {
			int customerId = 1;
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			IRegistration registration = _mockery.DynamicMock< IRegistration >( );
			using ( _mockery.Record( ) ) {
				SetupResult.For( registration.FirstName( ) ).Return( "mo" );
				SetupResult.For( registration.Username( ) ).Return( "mokhan" );
				SetupResult.For( registration.LastName( ) ).Return( "khan" );
				SetupResult.For( registration.PhoneNumber( ) ).Return( "4036813389" );
				SetupResult.For( registration.City( ) ).Return( "calgary" );

				SetupResult.For( customer.Registration( ) ).Return( registration );
				Expect.Call( _mockCustomerRepository.FindBy( customerId ) ).Return( customer );
			}

			using ( _mockery.Playback( ) ) {
				Assert.AreEqual(
					new CustomerRegistrationDisplayDTO( "1", "mokhan", "mo", "khan", "4036813389", "calgary" ),
					CreateSUT( ).LoadRegistrationFor( customerId ) );
			}
		}

		[Test]
		public void Should_leverage_repository_to_update_the_customer_information() {
			int customerId = 1;
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			IRegistration registration = _mockery.DynamicMock< IRegistration >( );
			using ( _mockery.Record( ) ) {
				SetupResult.For( customer.Registration( ) ).Return( registration );
				SetupResult.For( registration.IsValid( ) ).Return( true );

				using ( _mockery.Ordered( ) ) {
					Expect.Call( _mockCustomerRepository.FindBy( customerId ) ).Return( customer );
					customer.UpdateRegistrationTo( "mokhan", "password", "mo", "khan", "4036813389", "calgary" );
					_mockCustomerRepository.Save( customer );
				}
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).UpdateRegistrationFor(
					new UpdateCustomerRegistrationDTO( 1, "mokhan", "password", "mo", "khan", "4036813389", "calgary" ) );
			}
		}

		[Test]
		public void Should_not_save_customer_if_registration_information_is_incorrect() {
			int customerId = 1;
			ICustomer customer = _mockery.DynamicMock< ICustomer >( );
			IRegistration registration = _mockery.DynamicMock< IRegistration >( );

			using ( _mockery.Record( ) ) {
				SetupResult.For( customer.Registration( ) ).Return( registration );
				SetupResult.For( registration.IsValid( ) ).Return( false );
				SetupResult.For( _mockCustomerRepository.FindBy( customerId ) ).Return( customer );
			}

			using ( _mockery.Playback( ) ) {
				CreateSUT( ).UpdateRegistrationFor(
					new UpdateCustomerRegistrationDTO( 1, "mokhan", "password", "mo", "khan", "4036813389", "calgary" ) );
			}
		}
	}
}