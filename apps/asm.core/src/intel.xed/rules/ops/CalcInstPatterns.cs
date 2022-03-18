//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public Index<InstPattern> CalcInstPatterns()
            => CalcInstPatterns(CalcInstDefs());

        Index<InstPattern> CalcInstPatterns(Index<InstDef> defs)
        {
            var dst = bag<InstPattern>();
            iter(defs, def => calc(def, dst), true);
            var data = dst.ToArray().Sort();
            return Data(nameof(CalcInstPatterns), () => data);
        }

        static void calc(in InstDef def, ConcurrentBag<InstPattern> dst)
        {
            var specs = def.PatternSpecs;
            var buffer = list<PatternOpDetail>();
            for(var j=0; j<specs.Count; j++)
            {
                ref readonly var spec = ref specs[j];
                buffer.Clear();
                ref readonly var ops = ref spec.OpSpecs;
                for(byte k=0; k<ops.Count; k++)
                    buffer.Add(detail(spec,k));
                dst.Add(new InstPattern(def, spec, buffer.ToArray()));
            }
        }

        static PatternOpDetail detail(in InstPatternSpec src, byte k)
        {
            ref readonly var ops = ref src.OpSpecs;
            var parser = RuleOpParser.create();
            ref readonly var op = ref ops[k];
            var detail = PatternOpDetail.Empty;
            var spec = parser.ParseOp(k, op.Name, op.Expression);
            var attribs = spec.Attribs.Sort();
            detail.InstId = src.InstId;
            detail.PatternId = src.PatternId;
            detail.OpIndex = op.Index;
            detail.Name = spec.Name;
            detail.Kind = spec.Kind;
            detail.Expression = op.Expression;
            detail.Mnemonic = src.Class;
            var opwidth = OperandWidthCode.INVALID;
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
            if(attribs.Search(RuleOpClass.EncGroup, out var encgroup))
                detail.EncGroup = encgroup;
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