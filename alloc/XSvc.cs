//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        public static SymHeaps SymHeaps(this IWfRuntime wf)
            => Z0.SymHeaps.create(wf);
    }
}