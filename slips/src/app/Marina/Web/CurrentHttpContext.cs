using System;
using System.Collections;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using System.Web.Profile;
using System.Web.SessionState;

namespace Marina.Web {
	public class CurrentHttpContext : IHttpContext {
		public void AddError( Exception errorInfo ) {
			Current( ).AddError( errorInfo );
		}

		public void ClearError() {
			Current( ).ClearError( );
		}

		public object GetSection( string sectionName ) {
			return Current( ).GetSection( sectionName );
		}

		public void RewritePath( string path ) {
			Current( ).RewritePath( path );
		}

		public void RewritePath( string path, bool rebaseClientPath ) {
			Current( ).RewritePath( path, rebaseClientPath );
		}

		public void RewritePath( string filePath, string pathInfo, string queryString ) {
			Current( ).RewritePath( filePath, pathInfo, queryString );
		}

		public void RewritePath( string filePath, string pathInfo, string queryString, bool setClientFilePath ) {
			Current( ).RewritePath( filePath, pathInfo, queryString, setClientFilePath );
		}

		public HttpApplication ApplicationInstance {
			get { return Current( ).ApplicationInstance; }
			set { Current( ).ApplicationInstance = value; }
		}

		public HttpApplicationState Application {
			get { return Current( ).Application; }
		}

		public IHttpHandler Handler {
			get { return Current( ).Handler; }
			set { Current( ).Handler = value; }
		}

		public IHttpHandler PreviousHandler {
			get { return Current( ).PreviousHandler; }
		}

		public IHttpHandler CurrentHandler {
			get { return Current( ).CurrentHandler; }
		}

		public HttpRequest Request {
			get { return Current( ).Request; }
		}

		public HttpResponse Response {
			get { return Current( ).Response; }
		}

		public TraceContext Trace {
			get { return Current( ).Trace; }
		}

		public IDictionary Items {
			get { return Current( ).Items; }
		}

		public HttpSessionState Session {
			get { return Current( ).Session; }
		}

		public HttpServerUtility Server {
			get { return Current( ).Server; }
		}

		public Exception Error {
			get { return Current( ).Error; }
		}

		public Exception[] AllErrors {
			get { return Current( ).AllErrors; }
		}

		public IPrincipal User {
			get { return Current( ).User; }
			set { Current( ).User = value; }
		}

		public ProfileBase Profile {
			get { return Current( ).Profile; }
		}

		public bool SkipAuthorization {
			get { return Current( ).SkipAuthorization; }
			set { Current( ).SkipAuthorization = value; }
		}

		public bool IsDebuggingEnabled {
			get { return Current( ).IsDebuggingEnabled; }
		}

		public bool IsCustomErrorEnabled {
			get { return Current( ).IsCustomErrorEnabled; }
		}

		public DateTime Timestamp {
			get { return Current( ).Timestamp; }
		}

		public Cache Cache {
			get { return Current( ).Cache; }
		}

		public RequestNotification CurrentNotification {
			get { return Current( ).CurrentNotification; }
		}

		public bool IsPostNotification {
			get { return Current( ).IsPostNotification; }
		}

		private HttpContext Current() {
			return HttpContext.Current;
		}
	}
}