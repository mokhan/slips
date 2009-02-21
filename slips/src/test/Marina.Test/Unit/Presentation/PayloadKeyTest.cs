using System;
using System.Collections.Specialized;
using Marina.Presentation;
using MbUnit.Framework;

namespace Marina.Test.Unit.Presentation {
	[TestFixture]
	public class PayloadKeyTest {
		[Test]
		public void Should_be_able_to_convert_an_item_from_the_payload_into_an_item_of_the_correct_type( ) {
			string key = "DID";
			int expectedValue = 1;

			NameValueCollection payload = new NameValueCollection( );
			payload.Add( key, expectedValue.ToString( ) );

			int actualValue = CreateSUT< int >( key ).ParseFrom( payload );
			Assert.AreEqual( expectedValue, actualValue );
		}

		[Test]
		[ExpectedException( typeof( Exception ) )]
		public void Should_not_be_able_to_parse_if_the_item_in_the_payload_does_not_match_the_data_type_for_the_key( ) {
			NameValueCollection payload = new NameValueCollection( );
			payload.Add( "DID", "NotAnInt" );
			CreateSUT< int >( "DID" ).ParseFrom( payload );
		}

		[Test]
		public void Should_be_able_to_implicitly_cast_to_a_string( ) {
			string implictlyCasted = CreateSUT< int >( "DID" );
			Assert.AreEqual( "DID", implictlyCasted );
		}

		[Test]
		[ExpectedException( typeof( PayloadKeyNotFoundException ) )]
		public void Should_return_default_value_if_key_is_not_in_payload( ) {
			CreateSUT< string >( "NOTINPAYLOAD" ).ParseFrom( new NameValueCollection( ) );
		}

		private PayloadKey< T > CreateSUT< T >( string key ) {
			return new PayloadKey< T >( key );
		}
	}
}