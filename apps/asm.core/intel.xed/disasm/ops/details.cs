//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;
    using static XedFields;

    partial class XedDisasm
    {
        static ConstLookup<Summary,Detail> details(Index<Summary> src, bool pll = true)
        {
            var dst = cdict<Summary,Detail>();
            iter(src, doc => dst.TryAdd(doc, new Detail(doc.File, XedDisasm.blocks(doc))), pll);
            return dst;
        }
    }
}
