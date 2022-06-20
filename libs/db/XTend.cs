//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public static partial class XTend
    {
        public static AppDb AppDb(this IWfRuntime wf)
            => Z0.AppDb.Service;
    }
}