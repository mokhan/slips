using Marina.Domain;
using Marina.Domain.Interfaces;
using Marina.Infrastructure;
using MbUnit.Framework;

namespace Marina.Test.Unit.Domain {
	[TestFixture]
	public class CustomerRegistrationTest {
		public IRegistration CreateSUT( string userName, string password ) {
			return new CustomerRegistration( userName, password, "mo", "khan", "4036813389", "calgary" );
		}

		[Test]
		public void Should_not_allow_blank_password() {
			string blankPassword = string.Empty;
			IRegistration registration = CreateSUT( "username", blankPassword );
			IRichList< IBrokenRule > brokenRules = ListFactory.From( registration.BrokenRules( ) );

			Assert.IsFalse( registration.IsValid( ) );
			Assert.AreEqual( "Password cannot be blank", brokenRules[ 0 ].Message( ) );
		}

		[Test]
		public void Should_not_allow_blank_username() {
			string blankUserName = string.Empty;
			IRegistration registration = CreateSUT( blankUserName, "password" );
			IRichList< IBrokenRule > brokenRules = ListFactory.From( registration.BrokenRules( ) );

			Assert.IsFalse( registration.IsValid( ) );
			Assert.AreEqual( "Username cannot be blank", brokenRules[ 0 ].Message( ) );
		}

		[Test]
		public void Should_be_valid() {
			Assert.IsTrue( CreateSUT( "username", "password" ).IsValid( ) );
		}

		[Test]
		public void Shoud_return_no_broken_rules() {
			IRegistration registration = CreateSUT( "userName", "PASSWORD" );
			IRichList< IBrokenRule > brokenRules = ListFactory.From( registration.BrokenRules( ) );
			Assert.AreEqual( 0, brokenRules.Count );
		}

		[Test]
		public void Should_be_equal() {
			Assert.AreEqual( CreateSUT( "mokhan", "password" ), CreateSUT( "mokhan", "password" ) );
		}
	}
}