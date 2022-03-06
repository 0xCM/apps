//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
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
            EmitTokens();
            EmitIsaForms();
            EmitRegmap();
            Rules.EmitCatalog();
        }

        void EmitRegmap()
            => TableEmit(CalcRegMap().Entries, RegMapEntry.RenderWidths, XedPaths.Table<RegMapEntry>());
    }
}