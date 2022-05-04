//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static XedRules;

    partial class IntelXed
    {
        public void EmitCatalog()
        {
            XedPaths.Targets().Delete();
            Emit(XedFields.Defs.Positioned);
            exec(PllExec,
                EmitChipMap,
                ImportForms,
                EmitRegmaps,
                EmitBroadcastDefs,
                () => Rules.EmitCatalog()
                );
            Db.EmitArtifacts();
        }

        public void Emit(ReadOnlySpan<FieldDef> src)
            => TableEmit(src, FieldDef.RenderWidths, XedPaths.Table<FieldDef>());
    }
}