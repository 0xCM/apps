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
            XedPaths.Targets().Clear(true);

            exec(true,
                EmitChipMap,
                ImportForms,
                EmitRegmap,
                EmitBroadcastDefs,
                () => Rules.EmitCatalog()
                );
        }

        void EmitRegmap()
            => TableEmit(XedRegMap.Service.Entries, RegMapEntry.RenderWidths, XedPaths.Table<RegMapEntry>());
    }
}