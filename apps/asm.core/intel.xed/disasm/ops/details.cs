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
        static ConstLookup<DisasmSummaryDoc,DisasmDetailDoc> details(Index<DisasmSummaryDoc> src, bool pll = true)
        {
            var dst = cdict<DisasmSummaryDoc,DisasmDetailDoc>();
            iter(src, doc => dst.TryAdd(doc, new DisasmDetailDoc(doc.File, XedDisasm.blocks(doc))), pll);
            return dst;
        }
    }
}
