using System;
using System.Collections.Generic;
using System.Text;
using Marina.Domain.Interfaces;

namespace Marina.Domain {
	public class Utilities {
		public static readonly IUtility Water = new Utility( "Water" );
		public static readonly IUtility Electrical = new Utility( "Electrical" );
		private static readonly IUtility None = new Utility( "None" );

		public static IUtility For( params IUtility[] utilities ) {
			if ( null != utilities && 0 < utilities.Length ) {
				return new UtilityComposite( utilities );
			}
			return None;
		}

		private class Utility : IUtility, IEquatable< Utility > {
			private readonly string _name;

			public Utility( string name ) {
				_name = name;
			}

			public bool IsEnabled( IUtility utility ) {
				return Equals( utility );
			}

			public bool Equals( Utility utility ) {
				if ( utility == null ) {
					return false;
				}
				return Equals( _name, utility._name );
			}

			public override bool Equals( object obj ) {
				if ( ReferenceEquals( this, obj ) ) {
					return true;
				}
				return Equals( obj as Utility );
			}

			public override int GetHashCode() {
				return _name.GetHashCode( );
			}

			public override string ToString() {
				return _name;
			}
		}

		private class UtilityComposite : IUtility {
			private readonly IEnumerable< IUtility > _utilities;

			public UtilityComposite( params IUtility[] utilities ) {
				_utilities = new List< IUtility >( utilities );
			}

			public bool IsEnabled( IUtility utility ) {
				return Equals( utility );
			}

			public override bool Equals( object obj ) {
				if ( ReferenceEquals( this, obj ) ) {
					return true;
				}
				foreach ( IUtility utility in _utilities ) {
					if ( utility != null ) {
						if ( utility.Equals( obj ) ) {
							return true;
						}
					}
				}
				return false;
			}

			public override int GetHashCode() {
				return 0;
			}

			public override string ToString() {
				StringBuilder builder = new StringBuilder( );
				foreach ( IUtility utility in _utilities ) {
					builder.Append( utility.ToString( ) );
				}
				return builder.ToString( );
			}
		}
	}
}