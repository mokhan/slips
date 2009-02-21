using System;
using System.Web;
using Marina.Infrastructure.Logging.Interfaces;
using Marina.Web.Views;

namespace Marina.Web {
	public class UnhandledExceptionsHttpModule : IHttpModule {
		public void Init( HttpApplication context ) {
			context.Error += delegate {
			                 	foreach ( Exception exception in context.Context.AllErrors ) {
			                 		Log.For( this ).CriticalError( exception.ToString( ) );
			                 	}
			                 	Redirect.To( WebViews.Login );
			                 };
		}

		public void Dispose() {}
	}
}