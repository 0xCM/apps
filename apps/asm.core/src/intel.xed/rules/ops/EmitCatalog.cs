//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
    using static core;

    partial class XedRules
    {
        public void EmitCatalog()
        {
            EmitPatterns();
            EmitPatternDetails();
            EmitRuleTables();
            EmitFieldDefs();
            EmitRuleSeq();
            EmitOperandWidths();
            EmitPointerWidths();
            EmitOpCodeKinds();
            EmitMacroAssignments();
            EmitFieldSpecs();
        }

        void EmitRuleTables()
        {
            var tables = CalcRuleTables();
            var sigs = tables.Keys.ToArray().Sort();
            var path = AppDb.XedPath("xed.rules.tables", FileKind.Txt);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            for(var i=0; i<sigs.Length; i++)
                writer.WriteLine(tables[skip(sigs,i)].Format());

            EmittedFile(emitting, sigs.Length);
        }

        Index<OpWidth> EmitOperandWidths()
        {
            var src = CalcOperandWidths();
            TableEmit(src.View, AppDb.XedTable<OpWidth>());
            return src;
        }

        Index<PointerWidthInfo> EmitPointerWidths()
        {
            var src = mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i));
            var dst = XedPaths.DocTarget(XedDocKind.PointerWidths);
            TableEmit(src.View, PointerWidthInfo.RenderWidths, dst);
            return src;
        }
    }
}