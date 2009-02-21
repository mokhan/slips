using System;
using System.Collections.Generic;
using System.Web.UI;
using Marina.Presentation.DTO;
using Marina.Presentation.Presenters;
using Marina.Presentation.Views;

namespace Marina.Web.UI {
	public partial class DockView : Page, IDockView {
		protected DockDisplayDTO DTO;

		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );
			new DockPresenter( this ).Initialize( );
		}

		public void Display( DockDisplayDTO dto ) {
			DTO = dto;
		}

		public void Display( IEnumerable< SlipDisplayDTO > availableSlips ) {
			uxSlipsRepeater.DataSource = availableSlips;
			uxSlipsRepeater.DataBind( );
		}
	}
}