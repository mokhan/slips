using System;
using System.Web.UI;
using Marina.Presentation.DTO;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;

namespace Marina.Web.UI {
	public partial class LeaseSlip : Page, ILeaseSlipView {
		protected void Page_Load( object sender, EventArgs e ) {
			ILeaseSlipPresenter presenter = new LeaseSlipPresenter( this );
			presenter.Initialize( );
			uxSubmitButton.Click += delegate { presenter.SubmitLeaseRequest( ); };
		}

		public SlipDisplayDTO Slip;
		public string ResponseMessage;

		public void Display( SlipDisplayDTO slip ) {
			Slip = slip;
		}

		public void Display( DisplayResponseLineDTO response ) {
			ResponseMessage = response.Message;
		}
	}
}