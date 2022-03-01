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
            //var encrules = EmitEncRulePatterns(enc);
            var dec = EmitDecInstDefs();
            //var decrules = EmitDecRulePatterns(dec);
            var rules = EmitRulePatterns(enc,dec);
            EmitFieldDefs();
            EmitEncRuleTables();
            EmitDecRuleTables();
            EmitEncDecRuleTables();
            EmitOperandWidths();
            EmitPointerWidths();
            EmitOcMapKind();
            EmitRuleOpCodes(rules);
            EmitEncPatternOps(enc);
            EmitDecPatternOps(dec);
        }

        FS.FilePath EmitEncInstDefs(ReadOnlySpan<InstDef> src)
            => EmitInstDefs(src, XedPaths.DocTarget(XedDocKind.EncInstDef));

        FS.FilePath EmitDecInstDefs(ReadOnlySpan<InstDef> src)
            => EmitInstDefs(src, XedPaths.DocTarget(XedDocKind.DecInstDef));

        FS.FilePath EmitEncRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, XedPaths.DocTarget(XedDocKind.EncRuleTable));

        FS.FilePath EmitDecRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, XedPaths.DocTarget(XedDocKind.DecRuleTable));

        FS.FilePath EmitEncDecRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, XedPaths.DocTarget(XedDocKind.EncDecRuleTable));

        Index<OperandWidth> EmitOperandWidths()
        {
            var src = ParseOperandWidths();
            var dst = ProjectDb.TablePath<OperandWidth>("xed");
            TableEmit(src.View,dst);
            return src;
        }

        Index<PointerWidthInfo> EmitPointerWidths()
        {
            var src = mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i));
            var dst = XedPaths.DocTarget(XedDocKind.PointerNames);
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

        Index<InstDef> EmitEncInstDefs()
        {
            var src = ParseEncInstDefs();
            EmitEncInstDefs(src);
            return src;
        }

        Index<InstDef> EmitDecInstDefs()
        {
            var src = ParseDecInstDefs();
            EmitDecInstDefs(src);
            return src;
        }

        Index<RuleTable> EmitEncRuleTables()
        {
            var src = ParseEncRuleTables();
            EmitEncRuleTables(src);
            return src;
        }

        Index<RuleTable> EmitDecRuleTables()
        {
            var src = ParseDecRuleTables();
            EmitDecRuleTables(src);
            return src;
        }

        Index<RuleTable> EmitEncDecRuleTables()
        {
            var src = ParseEncDecRuleTables();
            EmitEncDecRuleTables(src);
            return src;
        }

        OpCodePatterns EmitOcMapKind()
        {
            var src = DeriveOpCodeMaps();
            TableEmit(src.Records, OcMapKind.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodePatterns));
            return src;
        }

        Index<RuleOpCode> EmitRuleOpCodes(ReadOnlySpan<RulePattern> src)
        {
            var opcodes = CalcOpCodes(src);
            TableEmit(opcodes.View, RuleOpCode.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodes));
            return opcodes;
        }
    }
}