//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public static Index<PatternOpInfo> CalcOpRecords(RuleTableSet tables, Index<InstPattern> src)
        {
            var buffer = list<PatternOpInfo>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i];
                ref readonly var ops = ref pattern.Ops;
                for(var j=0; j<ops.Count; j++)
                {
                    var dst = PatternOpInfo.Empty;
                    ref readonly var op = ref ops[j];

                    dst.InstId = pattern.InstId;
                    dst.PatternId = pattern.PatternId;
                    dst.InstClass = pattern.InstClass;
                    dst.Mode = pattern.Mode;
                    dst.OpCode = pattern.OpCode;
                    dst.Index = op.Index;
                    dst.Name = op.Name;
                    dst.Kind = op.Kind;
                    dst.Expression = op.Expression;
                    dst.NonTerm = (bit)XedFields.nonterm(op.Attribs, out dst.NonTerminal);
                    CalcOpProps(op, ref dst);
                    buffer.Add(dst);
                }
            }

            return buffer.ToArray().Sort();
        }

        static void CalcOpProps(in PatternOp op, ref PatternOpInfo dst)
        {
            ref readonly var attribs = ref op.Attribs;
            if(attribs.Search(OpClass.Action, out var a))
                dst.Action = a.AsAction();
            if(attribs.Search(OpClass.OpWidth, out var w))
            {
                dst.OpWidth = w.AsOpWidth();
                dst.BitWidth = dst.OpWidth.Bits;
            }
            if(attribs.Search(OpClass.ElementType, out var et))
            {
                dst.CellType = et.AsElementType();
                dst.CellWidth = bitwidth(dst.OpWidth.Code, dst.CellType);
            }
            if(attribs.Search(OpClass.RegLiteral, out var reglit))
            {
                dst.RegLit = reglit.AsRegLiteral();
                dst.BitWidth = bitwidth(dst.RegLit);
            }
            if(attribs.Search(OpClass.Modifier, out var mod))
                dst.Modifier = mod.AsModifier();

            if(attribs.Search(OpClass.Visibility, out var visib))
                dst.Visibility = visib.AsVisibility();
        }
    }
}