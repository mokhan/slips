using System;
using System.Collections.Generic;
using System.Web.UI;
using Marina.Presentation.DTO;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;

namespace Marina.Web.UI {
	public partial class Login : Page, ILoginView {
		protected void Page_Load( object sender, EventArgs e ) {
			ILoginPresenter presenter = new LoginPresenter( this );
			uxLoginButton.Click += delegate { presenter.Login( ); };
		}

		public void Display( DisplayResponseLineDTO responseMessage ) {
			IList< DisplayResponseLineDTO > messages = new List< DisplayResponseLineDTO >( );
			messages.Add( responseMessage );
			uxResponseMessagesRepeater.DataSource = messages;
			uxResponseMessagesRepeater.DataBind( );
		}
	}
}