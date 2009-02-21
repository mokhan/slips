using System;
using System.Collections;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using System.Web.Profile;
using System.Web.SessionState;

namespace Marina.Web {
	public interface IHttpContext {
		void AddError( Exception errorInfo );

		void ClearError( );

		object GetSection( string sectionName );

		void RewritePath( string path );

		void RewritePath( string path, bool rebaseClientPath );

		void RewritePath( string filePath, string pathInfo, string queryString );

		void RewritePath( string filePath, string pathInfo, string queryString, bool setClientFilePath );

		HttpApplication ApplicationInstance { get; set; }

		HttpApplicationState Application { get; }

		IHttpHandler Handler { get; set; }

		IHttpHandler PreviousHandler { get; }

		IHttpHandler CurrentHandler { get; }

		HttpRequest Request { get; }

		HttpResponse Response { get; }

		TraceContext Trace { get; }

		IDictionary Items { get; }

		HttpSessionState Session { get; }

		HttpServerUtility Server { get; }

		Exception Error { get; }

		Exception[] AllErrors { get; }

		IPrincipal User { get; set; }

		ProfileBase Profile { get; }

		bool SkipAuthorization { get; set; }

		bool IsDebuggingEnabled { get; }

		bool IsCustomErrorEnabled { get; }

		DateTime Timestamp { get; }

		Cache Cache { get; }

		RequestNotification CurrentNotification { get; }

		bool IsPostNotification { get; }
	}
}