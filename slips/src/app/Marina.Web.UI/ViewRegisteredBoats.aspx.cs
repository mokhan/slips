using System;
using System.Collections.Generic;
using System.Web.UI;
using Marina.Presentation.DTO;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;

namespace Marina.Web.UI {
	public partial class ViewRegisteredBoats : Page, IRegisteredBoatsView {
		protected void Page_Load( object sender, EventArgs e ) {
			new ViewRegisteredBoatsPresenter( this ).Initialize( );
		}

		public void Display( IEnumerable< BoatRegistrationDTO > boats ) {
			uxBoatsRepeater.DataSource = boats;
			uxBoatsRepeater.DataBind( );
		}
	}
}