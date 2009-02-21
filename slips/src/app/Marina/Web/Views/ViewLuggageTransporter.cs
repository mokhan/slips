using System.Collections;
using System.Web;

namespace Marina.Web.Views {
	public class ViewLuggageTransporter< Luggage > : IViewLuggageTransporter< Luggage > {
		public ViewLuggageTransporter( IViewLuggageTicket< Luggage > key ) : this( key, HttpContext.Current.Items ) {}

		private ViewLuggageTransporter( IViewLuggageTicket< Luggage > key, IDictionary items ) {
			_ticket = key;
			_items = items;
		}

		public Luggage Value() {
			foreach ( DictionaryEntry entry in _items ) {
				if ( entry.Value is Luggage ) {
					return ( Luggage )entry.Value;
				}
				//if ( entry.Key.Equals( _ticket ) ) {
				//    return ( Luggage )entry.Value;
				//}
			}
			return default( Luggage );
		}

		public void Add( Luggage value ) {
			_items.Add( _ticket, value );
		}

		private readonly IViewLuggageTicket< Luggage > _ticket;
		private readonly IDictionary _items;
	}
}