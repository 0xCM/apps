//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
    using static core;
    using static Root;

    using static XedModels.RuleNames;

    using EK = XedModels.RuleExprKind;

    partial class XedRules
    {
        public void EmitCatalog()
        {
            var enc = EmitEncInstDefs();
            var dec = EmitDecInstDefs();
            EmitRulePatterns(enc,dec);
            EmitEncRuleTables();
            EmitDecRuleTables();
            EmitEncDecRuleTables();
            EmitOperandWidths();
            EmitPointerWidths();
            EmitOpCodeMaps();
        }

        public FS.FilePath EmitEncInstDefs(ReadOnlySpan<InstDef> src)
            => EmitInstDefs(src, RuleTarget(RuleDocKind.EncInstDef));

        public FS.FilePath EmitDecInstDefs(ReadOnlySpan<InstDef> src)
            => EmitInstDefs(src, RuleTarget(RuleDocKind.DecInstDef));

        public FS.FilePath EmitEncRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, RuleTarget(RuleDocKind.EncRuleTable));

        public FS.FilePath EmitDecRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, RuleTarget(RuleDocKind.DecRuleTable));

        public FS.FilePath EmitEncDecRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, RuleTarget(RuleDocKind.EncDecRuleTable));

        public Index<OperandWidth> EmitOperandWidths()
        {
            var src = ParseOperandWidths();
            var dst = ProjectDb.TablePath<OperandWidth>("xed");
            TableEmit(src.View,dst);
            return src;
        }

        public Index<PointerWidthRecord> EmitPointerWidths()
        {
            var src = mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i));
            var dst = RuleTarget(RuleDocKind.PointerWidths);
            TableEmit(src.View, PointerWidthRecord.RenderWidths, dst);
            return src;
        }

        Index<RulePattern> EmitRulePatterns(Index<InstDef> x, Index<InstDef> y)
        {
            var enc = x.SelectMany(x => x.PatternOps).Select(x => x.Pattern).Distinct().Sort();
            var dec = y.SelectMany(x => x.PatternOps).Select(x => x.Pattern).Distinct().Sort();
            var count = Require.equal(enc.Count, dec.Count);
            var patterns = ExtractRulePatterns(x);
            var path = RuleTarget(RuleDocKind.Patterns);
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

        public OpCodeMaps EmitOpCodeMaps()
        {
            var src = DeriveOpCodeMaps();
            var dst = ProjectDb.TablePath<OpCodeMap>("xed");
            TableEmit(src.Records, OpCodeMap.RenderWidths, dst);
            return src;
        }

    }
}