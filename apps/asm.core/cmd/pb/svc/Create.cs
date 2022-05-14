//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static PolyBits PolyBits(this IWfRuntime wf)
            => Z0.PolyBits.create(wf);
    }
}
