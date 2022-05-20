//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public static class XSvc
    {
        [Op]
        public static IntelIntrinsicSvc IntelIntrinsics(this IWfRuntime wf)
            => IntelIntrinsicSvc.create(wf);

        [Op]
        public static Z0.IntelInstrinsicsCmd IntelIntrinsicsCmd(this IWfRuntime wf)
            => Z0.IntelInstrinsicsCmd.create(wf);
    }
}