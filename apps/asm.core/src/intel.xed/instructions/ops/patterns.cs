//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedPatterns
    {
        public static Index<InstPattern> patterns(Index<InstDef> defs, bool pll = true)
        {
            var dst = bag<InstPattern>();
            iter(defs, def => patterns(def, dst), pll);
            return dst.ToArray().Sort();
        }

        static void patterns(in InstDef def, ConcurrentBag<InstPattern> dst)
        {
            var specs = def.PatternSpecs;
            var buffer = list<InstPatternOps>();
            for(var j=0; j<specs.Count; j++)
            {
                ref readonly var spec = ref specs[j];
                buffer.Clear();
                for(byte k=0; k<spec.OpSpecs.Count; k++)
                    buffer.Add(ops(spec,k));
                dst.Add(new InstPattern(def, spec, buffer.ToArray()));
            }
        }

        static InstPatternOps ops(in InstPatternSpec src, byte k)
        {
            ref readonly var ops = ref src.OpSpecs;
            ref readonly var op = ref ops[k];
            var detail = InstPatternOps.Empty;
            var spec = RuleOpParser.parse(k, op.Name, op.Expression);
            var attribs = spec.Attribs.Sort();
            detail.InstId = src.InstId;
            detail.PatternId = src.PatternId;
            detail.OpIndex = op.Index;
            detail.Name = spec.Name;
            detail.Kind = spec.Kind;
            detail.Expression = op.Expression;
            detail.Mnemonic = src.Class;
            var opwidth = OpWidthCode.INVALID;
            if(attribs.Search(RuleOpClass.Action, out var action))
                detail.Action = action;
            if(attribs.Search(RuleOpClass.OpWidth, out var w))
            {
                detail.WidthCode = w;
                opwidth = w.AsOpWidth();
                detail.BitWidth = XedModels.bitwidth(opwidth);
            }
            if(attribs.Search(RuleOpClass.ElementType, out var et))
            {
                detail.CellType = et;
                detail.CellWidth = bitwidth(opwidth,et.AsElementType());
            }
            if(attribs.Search(RuleOpClass.RegLiteral, out var reglit))
            {
                detail.RegLit = reglit;
                detail.BitWidth = XedModels.bitwidth(reglit.AsRegLiteral());
            }
            if(attribs.Search(RuleOpClass.Modifier, out var mod))
                detail.Modifier = mod;
            if(attribs.Search(RuleOpClass.Visibility, out var visib))
                detail.Visibility = visib;

            return detail;
        }
    }
}