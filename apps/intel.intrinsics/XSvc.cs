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
            public IntelIntrinsicSvc IntelIntrinsics(IWfRuntime wf)
                => Service<IntelIntrinsicSvc>(wf);

            public IntelInstrinsicsCmd IntelIntrinsicsCmd(IWfRuntime wf)
                => Service<IntelInstrinsicsCmd>(wf);

            public I.Checks Checks(IWfRuntime wf)
                => Service<I.Checks>(wf);
        }

        static Svc Services => Svc.Instance;

        public static IntelIntrinsicSvc IntelIntrinsics(this IWfRuntime wf)
            => Services.IntelIntrinsics(wf);

        public static IntelInstrinsicsCmd IntelIntrinsicsCmd(this IWfRuntime wf)
            => Services.IntelIntrinsicsCmd(wf);

        public static I.Checks Checks(this IWfRuntime wf)
            => Services.Checks(wf);
    }
}