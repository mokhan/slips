using System;
using System.Collections.Generic;
using System.Web.UI;
using Marina.Presentation.DTO;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;

namespace Marina.Web.UI {
	public partial class CurrentLeases : Page, ICurrentLeasesView {
		protected void Page_Load( object sender, EventArgs e ) {
			new CurrentLeasesPresenter( this ).Initialize( );
		}

		public void Display( IEnumerable< DisplayLeaseDTO > leases ) {
			uxLeasesRepeater.DataSource = leases;
			uxLeasesRepeater.DataBind( );
		}
	}
}