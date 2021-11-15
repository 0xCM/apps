//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static partial class XSvc
    {
        [Op]
        public static Roslyn Roslyn(this IWfRuntime wf)
            => Z0.Roslyn.create(wf);

        [Op]
        public static SourceSymbolic SourceSymbolic(this IWfRuntime wf)
            => Z0.SourceSymbolic.create(wf);
    }
}