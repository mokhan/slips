using System.Collections;
using Marina.Infrastructure.Container;
using Marina.Task;
using MbUnit.Core.Invokers;

namespace Marina.Test.Utility {
	public class RunInRealContainerRunInvoker : DecoratorRunInvoker {
		public RunInRealContainerRunInvoker( IRunInvoker invoker )
			: base( invoker ) {}

		public override object Execute( object o, IList args ) {
			ApplicationStartupTask.ApplicationBegin( );
			object result = base.Invoker.Execute( o, args );
			Resolve.InitializeWith( null );
			return result;
		}
	}
}