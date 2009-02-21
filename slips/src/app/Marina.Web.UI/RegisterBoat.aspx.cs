using System;
using System.Collections.Generic;
using System.Web.UI;
using Marina.Presentation.DTO;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;

namespace Marina.Web.UI {
	public partial class RegisterBoat : Page, IRegisterBoatView {
		protected void Page_Load( object sender, EventArgs e ) {
			IRegisterBoatPresenter presenter = new RegisterBoatPresenter( this );
			uxRegisterBoatButton.Click += delegate { presenter.SubmitRegistration( ); };
		}

		public void Display( IEnumerable< DisplayResponseLineDTO > response ) {
			uxResponseRepeater.DataSource = response;
			uxResponseRepeater.DataBind( );
		}
	}
}