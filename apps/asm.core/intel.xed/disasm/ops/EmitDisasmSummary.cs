//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    partial class XedDisasmSvc
    {
        void EmitDisasmSummary(Index<DisasmSummary> src, FS.FilePath dst)
            => TableEmit(src.View, DisasmSummary.RenderWidths, dst);
    }
}