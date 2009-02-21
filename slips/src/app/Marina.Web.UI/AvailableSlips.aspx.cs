using System;
using System.Collections.Generic;
using System.Web.UI;
using Marina.Presentation.DTO;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;
using Marina.Web.Views;

namespace Marina.Web.UI {
	public partial class AvailableSlips : Page, IAvailableSlipsView {
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );

			new AvailableSlipsPresenter( this ).Initialize( );
		}

		public void Display( IEnumerable< SlipDisplayDTO > availableSlips ) {
			ViewLuggage.TransporterFor( ViewLuggageTickets.AvailableSlips ).Add( availableSlips );
		}
	}
}