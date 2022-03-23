//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    partial class XedDisasmSvc
    {
        void EmitDisasmSummary(DisasmSummaryDocs docs, FS.FilePath dst)
            => TableEmit(CalcDisasmSummary(docs).View, AsmDisasmSummary.RenderWidths, dst);
    }
}