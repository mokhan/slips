using System;
using System.Collections.Generic;
using System.Web.UI;
using Marina.Presentation.DTO;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;

namespace Marina.Web.UI {
	public partial class UpdateCustomerRegistration : Page, IUpdateRegistrationView {
		protected void Page_Load( object sender, EventArgs e ) {
			UpdateCustomerRegistrationPresenter presenter = new UpdateCustomerRegistrationPresenter( this );
			presenter.Initialize( );
			uxUpdateButton.Click += delegate { presenter.UpdateRegistration( ); };
		}

		public void Display( CustomerRegistrationDisplayDTO customerRegistration ) {
			CustomerRegistration = customerRegistration;
		}

		public void Display( IEnumerable< DisplayResponseLineDTO > response ) {
			uxResponseMessagesRepeater.DataSource = response;
			uxResponseMessagesRepeater.DataBind( );
		}

		public CustomerRegistrationDisplayDTO CustomerRegistration;
	}
}