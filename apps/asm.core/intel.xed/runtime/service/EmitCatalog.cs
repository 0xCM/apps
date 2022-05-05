//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedOperands;
    using static XedPatterns;
    using static XedModels;
    using static core;

    partial class XedRuntime
    {
        public void EmitCatalog()
        {
            Paths.Targets().Delete();
            Emit(XedFields.Defs.Positioned);
            exec(PllExec,
                () => Main.EmitChipMap(),
                () => Main.ImportForms(),
                () => EmitRegmaps(),
                () => EmitBroadcastDefs(),
                () => Rules.EmitCatalog(Patterns,RuleTables),
                () => Emit(InstLayouts)
                );

            EmitInstPages(Patterns);
            EmitDocs(Patterns,RuleTables);
            Db.EmitArtifacts();
        }

        public void EmitDocs(Index<InstPattern> src, RuleTables rules)
            => Docs.Emit(src,rules);

        public void EmitInstPages(Index<InstPattern> src)
        {
            src.Sort();
            var formatter = InstPageFormatter.create();
            Paths.InstPageRoot().Delete();
            iter(formatter.GroupFormats(src), x =>  Emit(x), PllExec);
        }

        public void Emit(in InstIsaFormat src)
        {
            var dst = Paths.InstPagePath(src.Isa);
            Require.invariant(!dst.Exists);
            FileEmit(src.Content, src.LineCount, dst, TextEncodingKind.Asci);
        }

        public void EmitBroadcastDefs()
            => TableEmit(XedOperands.Views.BroadcastDefs, BroadcastDef.RenderWidths, Paths.Table<BroadcastDef>());

        public void Emit(ReadOnlySpan<FieldDef> src)
            => TableEmit(src, FieldDef.RenderWidths, Paths.Table<FieldDef>());

        public void EmitRegmaps()
        {
            TableEmit(XedRegMap.Service.REntries, RegMapEntry.RenderWidths, Paths.Table<RegMapEntry>("rmap"));
            TableEmit(XedRegMap.Service.XEntries, RegMapEntry.RenderWidths, Paths.Table<RegMapEntry>("xmap"));
        }

        void Emit(InstLayouts src)
        {
            FileEmit(src.Format(), 0, Paths.InstTarget("layouts.vectors", FileKind.Csv));
            TableEmit(src.Records.View, InstLayoutRecord.RenderWidths, Paths.InstTable<InstLayoutRecord>());
        }
    }
}