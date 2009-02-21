using System;
using System.Collections.Specialized;

namespace Marina.Presentation
{
    public class PayloadKey< T > : IEquatable< PayloadKey< T > >
    {
        private readonly string _key;

        public PayloadKey( string key )
        {
            _key = key;
        }

        public T ParseFrom( NameValueCollection payload )
        {
            EnsureKeyIsInPayload( payload );
            return ( T )Convert.ChangeType( payload[ _key ], typeof( T ) );
        }

        private void EnsureKeyIsInPayload( NameValueCollection payload )
        {
            if( null == payload[ _key ] ) {
                throw new PayloadKeyNotFoundException( _key );
            }
        }

        public static implicit operator string( PayloadKey< T > item )
        {
            return item._key;
        }

        public bool Equals( PayloadKey< T > payloadKey )
        {
            return payloadKey != null && Equals( _key, payloadKey._key );
        }

        public override bool Equals( object obj )
        {
            return ReferenceEquals( this, obj ) || Equals( obj as PayloadKey< T > );
        }

        public override int GetHashCode( )
        {
            return _key.GetHashCode( );
        }
    }
}