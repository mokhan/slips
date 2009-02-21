using System;
using System.Collections.Generic;
using System.Web.UI;
using Marina.Presentation.DTO;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;

namespace Marina.Web.UI {
	public partial class Registration : Page, ICustomerRegistrationView {
		protected void Page_Load( object sender, EventArgs e ) {
			ICustomerRegistrationPresenter presenter = new CustomerRegistrationPresenter( this );
			uxRegisterButton.Click += delegate { presenter.RegisterCustomer( ); };
		}

		public string UserName() {
			return Request.Params[ "uxUserNameTextBox" ];
		}

		public string Password() {
			return Request.Params[ "uxPasswordTextBox" ];
		}

		public string FirstName() {
			return Request.Params[ "uxFirstNameTextBox" ];
		}

		public string LastName() {
			return Request.Params[ "uxLastNameTextBox" ];
		}

		public string PhoneNumber() {
			return Request.Params[ "uxPhoneNumberTextBox" ];
		}

		public string City() {
			return Request.Params[ "uxCityTextBox" ];
		}

		public void Display( IEnumerable< DisplayResponseLineDTO > response ) {
			uxResponseMessagesRepeater.DataSource = response;
			uxResponseMessagesRepeater.DataBind( );
		}
	}
}