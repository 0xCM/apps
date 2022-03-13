//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        Index<PatternOpDetail> CalcPatternOps(Index<InstPattern> src)
            => src.SelectMany(x => x.OpDetails).Sort();

        static PatternOpDetail detail(in InstPatternSpec pattern, byte k)
        {
            ref readonly var ops = ref pattern.Operands;
            var parser = RuleOpParser.create();
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