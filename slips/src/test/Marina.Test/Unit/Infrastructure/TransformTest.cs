using System;
using System.Data;
using Marina.Infrastructure;
using MbUnit.Framework;

namespace Marina.Test.Unit.Infrastructure {
	[TestFixture]
	public class TransformerTest {
		[Test]
		public void Should_be_able_to_cast_to_the_actual_type_of_the_underlying_object( ) {
			object item = new Item( );

			Item result = CreateSUT( item ).To< Item >( );
			Assert.AreEqual( item, result );
		}

		[ExpectedException( typeof( NullReferenceException ) )]
		[Test]
		public void Should_not_be_able_to_cast_from_null_to_a_type( ) {
			CreateSUT( null ).To< Item >( );
		}

		[ExpectedException( typeof( InvalidCastException ) )]
		[Test]
		public void Should_not_be_able_to_cast_from_one_instance_to_a_non_assignable_type( ) {
			Item item = new Item( );

			CreateSUT( item ).To< IDbConnection >( );
		}

		private ITransformer CreateSUT( object item ) {
			return new Transformer( item );
		}

		private class Item {}
	}
}