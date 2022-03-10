//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedModels;

    partial class IntelXed
    {
        public void EmitCatalog()
        {
            XedPaths.Targets().Clear(true);
            EmitChipMap();
            ImportForms();
            EmitIsaForms();
            EmitRegmap();
            Rules.EmitCatalog();
        }

        void EmitRegmap()
            => TableEmit(XedRegMap.Service.Entries, RegMapEntry.RenderWidths, XedPaths.Table<RegMapEntry>());
    }
}