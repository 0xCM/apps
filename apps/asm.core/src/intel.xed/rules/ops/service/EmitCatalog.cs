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
            EmitEncRuleTables();
            EmitDecRuleTables();
            EmitEncDecRuleTables();
            EmitOperandWidths();
            EmitPointerWidths();
            EmitOpCodeKinds();
            EmitMacroAssignments();
            EmitRuleFields();
            EmitRuleOpCodes(rules);
            EmitEncPatternOps(enc);
            EmitDecPatternOps(dec);
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

        Index<RulePattern> EmitRulePatterns(Index<InstDef> enc, Index<InstDef> dec)
        {
            // var enc = a.SelectMany(x => x.PatternSpecs).Select(x => x.PatternExpr).Distinct().Sort();
            // var dec = b.SelectMany(x => x.PatternSpecs).Select(x => x.PatternExpr).Distinct().Sort();
            // var count = Require.equal(enc.Count, dec.Count);
            var patterns = CalcRulePatterns(enc);
            TableEmit(patterns.View, RulePattern.RenderWidths, XedPaths.DocTarget(XedDocKind.EncRulePatterns));
            TableEmit(CalcRulePatterns(dec).View, RulePattern.RenderWidths, XedPaths.DocTarget(XedDocKind.DecRulePatterns));
            return patterns;
        }

        Index<RuleOpCode> EmitRuleOpCodes(ReadOnlySpan<RulePattern> src)
        {
            var opcodes = CalcOpCodes(src);
            TableEmit(opcodes.View, RuleOpCode.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodes));
            return opcodes;
        }
    }
}