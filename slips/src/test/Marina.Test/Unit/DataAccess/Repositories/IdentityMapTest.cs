using Marina.DataAccess;
using Marina.DataAccess.Exceptions;
using Marina.Domain;
using Marina.Domain.Interfaces;
using MbUnit.Framework;

namespace Marina.Test.Unit.DataAccess.Repositories {
	[TestFixture]
	public class IdentityMapTest {
		public IIdentityMap< IDomainObject > CreateSUT() {
			return new IdentityMap< IDomainObject >( );
		}
		
		// should not be able to add an object with an id of -1

		[Test]
		public void Should_be_able_to_add_a_new_domain_object_to_the_identitiy_map() {
			IDomainObject objectThatHasBeenAddedToMap = new DomainObject( 1 );
			IDomainObject objectThatHasNotBeenAddedToMap = new DomainObject( 2 );

			IIdentityMap< IDomainObject > map = CreateSUT( );
			map.Add( objectThatHasBeenAddedToMap );

			Assert.IsTrue( map.ContainsObjectWithIdOf( objectThatHasBeenAddedToMap.ID( ) ) );
			Assert.IsFalse( map.ContainsObjectWithIdOf( objectThatHasNotBeenAddedToMap.ID( ) ) );
		}

		[Test]
		public void Should_return_true_if_searching_for_a_() {
			IIdentityMap< IDomainObject > map = CreateSUT( );

			int id = 1;
			map.Add( new DomainObject( id ) );

			Assert.IsTrue( map.ContainsObjectWithIdOf( id ) );
			Assert.IsFalse( map.ContainsObjectWithIdOf( 2 ) );
		}

		[Test]
		public void Should_be_able_to_retrieve_an_object_that_has_been_added_to_the_map() {
			IIdentityMap< IDomainObject > map = CreateSUT( );
			IDomainObject objectAddedToMap = new DomainObject( 1 );
			map.Add( objectAddedToMap );

			Assert.AreEqual( objectAddedToMap, map.FindObjectWithIdOf( 1 ) );
		}

		[Test]
		public void Should_return_null_if_the_object_is_not_in_the_map() {
			Assert.IsNull( CreateSUT( ).FindObjectWithIdOf( 1 ) );
		}

		[Test]
		[ExpectedException( typeof( ObjectAlreadyAddedToIdentityMapException ) )]
		public void Should_not_be_able_to_add_an_object_that_has_already_been_added() {
			IIdentityMap< IDomainObject > map = CreateSUT( );
			IDomainObject addedObject = new DomainObject( 1 );
			map.Add( addedObject );
			map.Add( addedObject );
		}

		[Test]
		[ExpectedException( typeof( ObjectAlreadyAddedToIdentityMapException ) )]
		public void Should_not_be_able_to_add_an_object_with_the_same_id_as_one_that_was_already_added() {
			IIdentityMap< IDomainObject > map = CreateSUT( );
			int id = 1;
			map.Add( new DomainObject( id ) );
			map.Add( new DomainObject( id ) );
		}
	}
}