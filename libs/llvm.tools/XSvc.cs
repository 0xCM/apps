//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using Z0.llvm;
    using Asm;

    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public LlvmConfigSvc LlvmConfig(IWfRuntime wf)
                => Service<LlvmConfigSvc>(wf);

        }

        static Svc Services = Svc.Instance;


        public static LlvmConfigSvc LlvmConfig(this IWfRuntime wf)
            => Services.LlvmConfig(wf);
    }
}