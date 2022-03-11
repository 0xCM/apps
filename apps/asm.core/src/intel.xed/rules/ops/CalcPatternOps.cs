//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public Index<PatternOpDetail> CalcPatternOps(Index<InstDef> defs)
        {
            var dst = bag<PatternOpDetail>();
            iter(defs, def => CalcPatternOps(def, dst), true);
            return dst.ToArray().Sort();
        }

        void CalcPatternOps(in InstDef def, ConcurrentBag<PatternOpDetail> dst)
        {
            ref readonly var patterns = ref def.PatternSpecs;
            RuleMacros.expand(patterns);
            for(var j=0; j<patterns.Count; j++)
            {
                CalcPatternOps(patterns[j], dst);
            }
        }

        void CalcPatternOps(in InstPatternSpec pattern, ConcurrentBag<PatternOpDetail> dst)
        {
            ref readonly var ops = ref pattern.Operands;
            var parser = RuleOpParser.create();
            for(byte k=0; k<ops.Count; k++)
            {
                ref readonly var op = ref ops[k];
                var detail = PatternOpDetail.Empty;
                var spec = parser.ParseOp(k, op.Name, op.Expression);

                var attribs = spec.Attribs.Sort();
                detail.InstId = pattern.InstId;
                detail.PatternId = pattern.PatternId;
                detail.OpIndex = op.Index;
                detail.Name = spec.Name;
                detail.Kind = spec.Kind;
                detail.Expression = op.Expression;
                detail.Mnemonic = pattern.Class;

                if(attrib(attribs, RuleOpClass.Action, out var action))
                    detail.Action = action;
                if(attrib(attribs, RuleOpClass.OpWidth, out var width))
                    detail.Width = width;
                if(attrib(attribs, RuleOpClass.ElementType, out var et))
                    detail.EType = et;
                if(attrib(attribs, RuleOpClass.EncGroup, out var encgroup))
                    detail.EncGroup = encgroup;
                if(attrib(attribs, RuleOpClass.RegLiteral, out var reglit))
                    detail.RegLit = reglit;
                if(attrib(attribs, RuleOpClass.Modifier, out var mod))
                    detail.Modifier = mod;
                if(attrib(attribs, RuleOpClass.Visibility, out var visib))
                    detail.Visibility = visib;

                dst.Add(detail);
            }
        }
    }
}