using System;
using System.Web;
using Marina.Infrastructure.Logging.Interfaces;
using Marina.Task;

namespace Marina.Web {
	public class GlobalApplication : HttpApplication {
		public void Application_Start( object sender, EventArgs e ) {
			ApplicationStartupTask.ApplicationBegin( );
			Log.For(this).Informational("Application Startup completed");
		}

		public void Application_Error( object sender, EventArgs e ) {
			Log.For( this ).Informational( "Unhandled error occurred" );
		}
	}
}