//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Tools;

    using static core;

    partial class XSvc
    {
        public static DumpParser DumpParser(this IWfRuntime wf)
            => Z0.DumpParser.create(wf);
    }
}