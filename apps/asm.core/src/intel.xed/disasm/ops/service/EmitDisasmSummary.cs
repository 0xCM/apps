//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasmSvc
    {
        void EmitDisasmSummary(AsmDisasmSummaryDocs docs, FS.FilePath dst)
        {
            var summaries = CalcDisasmSummary(docs);
            TableEmit(summaries.View, AsmDisasmSummary.RenderWidths, dst);
        }
    }
}