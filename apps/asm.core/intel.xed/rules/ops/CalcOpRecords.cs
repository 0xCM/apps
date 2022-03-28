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
        public static Index<PatternOpInfo> CalcOpRecords(Index<InstPattern> src)
        {
            var dst = list<PatternOpInfo>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i];
                ref readonly var ops = ref pattern.Ops;
                for(var j=0; j<ops.Count; j++)
                {
                    var op = PatternOpInfo.Empty;
                    CalcOpProps(ops[j], ref op);
                    op.InstId = pattern.InstId;
                    op.PatternId = pattern.PatternId;
                    op.InstClass = pattern.InstClass;
                    op.Mode = pattern.Mode;
                    op.OpCode = pattern.OpCode;
                    dst.Add(op);
                }
            }

            return dst.ToArray().Sort();
        }

        static void CalcOpProps(in PatternOp src, ref PatternOpInfo dst)
        {
            ref readonly var attribs = ref src.Attribs;
            dst.Index = src.Index;
            dst.Name = src.Name;
            dst.Kind = src.Kind;
            dst.Expression = src.Expression;
            dst.NonTerm = (bit)XedFields.nonterm(attribs, out dst.NonTerminal);
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