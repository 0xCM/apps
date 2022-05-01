//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedOpCodes;

    partial class XedRules
    {
        public void Emit(RuleTables src)
        {
            exec(PllExec,
                () => EmitCellDetail(CalcRuleCells(src)),
                () => EmitTableDefReport(src),
                () => Emit(CellParser.ruleseq()),
                () => Docs.EmitDocs(src),
                () => EmitTableDefs(src)
            );
        }

        public void Emit(OpCodeClass @class, ReadOnlySpan<InstGroupSeq> src)
            => TableEmit(src, InstGroupSeq.RenderWidths, XedPaths.Table<InstGroupSeq>(@class.ToString().ToLower()));

        public void Emit(Index<RuleSeq> src)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.Service.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }

        public void Emit(ReadOnlySpan<MacroMatch> src)
            => TableEmit(src, MacroMatch.RenderWidths, XedPaths.RuleTable<MacroMatch>());

        public void Emit(ReadOnlySpan<ReflectedField> src)
            => TableEmit(src, ReflectedField.RenderWidths, XedPaths.Table<ReflectedField>());

        public void Emit(ReadOnlySpan<RuleCellRecord> src)
            => TableEmit(src, RuleCellRecord.RenderWidths, XedPaths.RuleTable<RuleCellRecord>());

        public void Emit(ReadOnlySpan<MacroDef> src)
            => TableEmit(src, MacroDef.RenderWidths, XedPaths.RuleTable<MacroDef>());

        public void Emit(ReadOnlySpan<PointerWidthInfo> src)
            => TableEmit(src, PointerWidthInfo.RenderWidths, XedPaths.DocTarget(XedDocKind.PointerWidths));

        public void Emit(ReadOnlySpan<PatternOpCode> src)
        {
            TableEmit(src, PatternOpCode.RenderWidths, XedPaths.Table<PatternOpCode>());
            Emit(OpCodeIdentity.identify(src));
        }

        public void Emit(Index<InstOpDetail> src)
        {
            exec(PllExec,
            () => Emit(CalcInstOpRows(src)),
            () => Emit(CalcOpClasses(src))
            );
        }

        public void Emit(ReadOnlySpan<InstFieldRow> src)
            => TableEmit(src, InstFieldRow.RenderWidths, XedPaths.Table<InstFieldRow>());

        public void Emit(ReadOnlySpan<InstPatternRecord> src)
            => TableEmit(src, InstPatternRecord.RenderWidths, XedPaths.Table<InstPatternRecord>());

        public void Emit(ReadOnlySpan<InstOperandRow> src)
            => TableEmit(src, InstOperandRow.RenderWidths, XedPaths.DocTarget(XedDocKind.PatternOps));

        public void Emit(ReadOnlySpan<InstOpClass> src)
            => TableEmit(src, InstOpClass.RenderWidths, XedPaths.Table<InstOpClass>());

        public void Emit(ReadOnlySpan<InstLayout> src)
            => TableEmit(src, InstLayout.RenderWidths, XedPaths.Table<InstLayout>());

        public void Emit(ReadOnlySpan<XedFieldDef> src)
            => TableEmit(src, XedFieldDef.RenderWidths, XedPaths.Table<XedFieldDef>());

        public void Emit(ReadOnlySpan<OpCodeId> ids)
        {
            var dst = text.buffer();
            var count = ids.Length;
            var @class = InstClass.Empty;
            var ocbyte = Hex8.Zero;
            var @lock = uint2.Zero;
            var r=z16;
            var s=z16;
            for(var i=z16; i<count;i++,r++,s++)
            {
                ref readonly var id = ref skip(ids,i);
                if(id.Class != @class)
                {
                    r=0;
                    s=0;
                    @class = id.Class;
                }

                if(id.Byte != ocbyte)
                {
                    s=0;
                    ocbyte = id.Byte;
                }

                var _row = string.Format("{0,-18} | {1,-2} | {2,-2} | {3,-2}", id.Class, id.Byte, id.Lock, id.Mod.Glyph);
                var row = string.Format("{0,-6} | {1} | {2,-6} | {3,-6}", i, _row, r, s);
                if(i != count - 1)
                    dst.AppendLine(row);
                else
                    dst.Append(row);
            }

            FileEmit(dst.Emit(), count, XedPaths.Targets() + FS.file("xed.opcodes.identities", FS.Csv), TextEncodingKind.Asci);
        }
    }
}