using System;
using MbUnit.Core.Framework;
using MbUnit.Core.Invokers;

namespace Marina.Test.Utility
{
    public class RunInRealContainerAttribute : DecoratorPatternAttribute
    {
        public override IRunInvoker GetInvoker( IRunInvoker wrapper )
        {
            return new RunInRealContainerRunInvoker( wrapper );
        }
    }
}