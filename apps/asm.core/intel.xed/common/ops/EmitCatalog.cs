//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedModels;
    using static core;

    partial class IntelXed
    {
        public void EmitCatalog()
        {
            XedPaths.Targets().Delete();
            exec(PllExec,
                EmitChipMap,
                ImportForms,
                EmitRegmaps,
                EmitBroadcastDefs,
                () => Rules.EmitCatalog()
                );
        }

        void EmitRegmaps()
        {
            TableEmit(XedRegMap.Service.REntries, RegMapEntry.RenderWidths, XedPaths.Table<RegMapEntry>("rmap"));
            TableEmit(XedRegMap.Service.XEntries, RegMapEntry.RenderWidths, XedPaths.Table<RegMapEntry>("xmap"));
        }
    }
}