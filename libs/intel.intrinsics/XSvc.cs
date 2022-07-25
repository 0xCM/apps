//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using I=IntelIntrinsics;

    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public IntelIntrinsics IntelIntrinsics(IWfRuntime wf)
                => Service<IntelIntrinsics>(wf);

            public I.CmdSvc IntelIntrinsicsCmd(IWfRuntime wf)
                => Service<I.CmdSvc>(wf);

            public I.Checks Checks(IWfRuntime wf)
                => Service<I.Checks>(wf);
        }

        static Svc Services => Svc.Instance;

        public static IntelIntrinsics IntelIntrinsics(this IWfRuntime wf)
            => Services.IntelIntrinsics(wf);

        public static IAppCmdService IntelIntrinsicsCmd(this IWfRuntime wf)
            => Services.IntelIntrinsicsCmd(wf);

        public static I.Checks Checks(this IWfRuntime wf)
            => Services.Checks(wf);
    }
}