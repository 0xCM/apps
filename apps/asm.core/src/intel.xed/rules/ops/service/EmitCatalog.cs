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
            var enc = EmitEncInstDefs();
            var dec = EmitDecInstDefs();
            var rules = EmitRulePatterns(enc,dec);
            EmitFieldDefs();
            EmitRuleSeq();
            EmitEncRuleTables();
            EmitDecRuleTables();
            EmitEncDecRuleTables();
            EmitOperandWidths();
            EmitPointerWidths();
            EmitOpCodeKinds();
            EmitMacroAssignments();
            EmitRuleFields();
            EmitPatternDetails();
        }

        Index<OperandWidth> EmitOperandWidths()
        {
            var src = CalcOperandWidths();
            var dst = ProjectDb.TablePath<OperandWidth>("xed");
            TableEmit(src.View,dst);
            return src;
        }

        Index<PointerWidthInfo> EmitPointerWidths()
        {
            var src = mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i));
            var dst = XedPaths.DocTarget(XedDocKind.PointerWidths);
            TableEmit(src.View, PointerWidthInfo.RenderWidths, dst);
            return src;
        }

        Index<RulePatternInfo> EmitRulePatterns(Index<InstDef> enc, Index<InstDef> dec)
        {
            var patterns = CalcPatternInfo(enc);
            TableEmit(patterns.View, RulePatternInfo.RenderWidths, XedPaths.DocTarget(XedDocKind.EncRulePatterns));
            TableEmit(CalcPatternInfo(dec).View, RulePatternInfo.RenderWidths, XedPaths.DocTarget(XedDocKind.DecRulePatterns));
            return patterns;
        }

    }
}