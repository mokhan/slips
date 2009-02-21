using System.Collections.Generic;
using Marina.Presentation.DTO;

namespace Marina.Web.Views {
	public class ViewLuggageTickets {
		public static IViewLuggageTicket< IEnumerable< SlipDisplayDTO > > AvailableSlips =
			new ViewBagItem< IEnumerable< SlipDisplayDTO > >( );

		public static IViewLuggageTicket< IEnumerable< DisplayResponseLineDTO > > ResponseMessages =
			new ViewBagItem< IEnumerable< DisplayResponseLineDTO > >( );

		private class ViewBagItem< T > : IViewLuggageTicket< T > {}
	}
}