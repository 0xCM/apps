//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
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
            EmitOpCodePatterns();
            EmitOpCodes(rules);
            EmitOperandEncodings(enc);
            EmitOperandDecodings(dec);
        }

        public void EmitOperandEncodings(ReadOnlySpan<InstDef> src)
            => EmitOperands(src, XedPaths.RuleTarget(RuleDocKind.OperandEncoding));

        public void EmitOperandDecodings(ReadOnlySpan<InstDef> src)
            => EmitOperands(src, XedPaths.RuleTarget(RuleDocKind.OperandDecoding));

        public FS.FilePath EmitEncInstDefs(ReadOnlySpan<InstDef> src)
            => EmitInstDefs(src, XedPaths.RuleTarget(RuleDocKind.EncInstDef));

        public FS.FilePath EmitDecInstDefs(ReadOnlySpan<InstDef> src)
            => EmitInstDefs(src, XedPaths.RuleTarget(RuleDocKind.DecInstDef));

        public FS.FilePath EmitEncRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, XedPaths.RuleTarget(RuleDocKind.EncRuleTable));

        public FS.FilePath EmitDecRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, XedPaths.RuleTarget(RuleDocKind.DecRuleTable));

        public FS.FilePath EmitEncDecRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, XedPaths.RuleTarget(RuleDocKind.EncDecRuleTable));

        public Index<OperandWidth> EmitOperandWidths()
        {
            var src = ParseOperandWidths();
            var dst = ProjectDb.TablePath<OperandWidth>("xed");
            TableEmit(src.View,dst);
            return src;
        }

        public Index<PointerWidthInfo> EmitPointerWidths()
        {
            var src = mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i));
            var dst = XedPaths.RuleTarget(RuleDocKind.PointerWidths);
            TableEmit(src.View, PointerWidthInfo.RenderWidths, dst);
            return src;
        }

        Index<RulePattern> EmitRulePatterns(Index<InstDef> x, Index<InstDef> y)
        {
            var enc = x.SelectMany(x => x.PatternOps).Select(x => x.Expr).Distinct().Sort();
            var dec = y.SelectMany(x => x.PatternOps).Select(x => x.Expr).Distinct().Sort();
            var count = Require.equal(enc.Count, dec.Count);
            var patterns = ExtractRulePatterns(x);
            var path = XedPaths.RuleTarget(RuleDocKind.RulePatterns);
            TableEmit(patterns.View, RulePattern.RenderWidths, path);
            return patterns;
        }

        public Index<InstDef> EmitEncInstDefs()
        {
            var src = ParseEncInstDefs();
            EmitEncInstDefs(src);
            return src;
        }

        public Index<InstDef> EmitDecInstDefs()
        {
            var src = ParseDecInstDefs();
            EmitDecInstDefs(src);
            return src;
        }

        public Index<RuleTable> EmitEncRuleTables()
        {
            var src = ParseEncRuleTables();
            EmitEncRuleTables(src);
            return src;
        }

        public Index<RuleTable> EmitDecRuleTables()
        {
            var src = ParseDecRuleTables();
            EmitDecRuleTables(src);
            return src;
        }

        public Index<RuleTable> EmitEncDecRuleTables()
        {
            var src = ParseEncDecRuleTables();
            EmitEncDecRuleTables(src);
            return src;
        }

        public OpCodePatterns EmitOpCodePatterns()
        {
            var src = DeriveOpCodeMaps();
            TableEmit(src.Records, OpCodePattern.RenderWidths, XedPaths.RuleTarget(RuleDocKind.OpCodePatterns));
            return src;
        }

        public Index<XedOpCodeRecord> EmitOpCodes(ReadOnlySpan<RulePattern> src)
        {
            var opcodes = ExtractOpCodes(src);
            TableEmit(opcodes.View, XedOpCodeRecord.RenderWidths, XedPaths.RuleTarget(RuleDocKind.OpCodes));
            return opcodes;
        }
    }
}