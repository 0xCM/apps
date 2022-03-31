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
        public static Index<PatternOpRow> CalcOpRecords(RuleTableSet tables, Index<InstPattern> src)
        {
            var buffer = list<PatternOpRow>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i];
                ref readonly var ops = ref pattern.Ops;
                for(var j=0; j<ops.Count; j++)
                {
                    var dst = PatternOpRow.Empty;
                    ref readonly var op = ref ops[j];
                    var info = op.Describe();
                    dst.InstId = pattern.InstId;
                    dst.PatternId = pattern.PatternId;
                    dst.InstClass = pattern.InstClass;
                    dst.Mode = pattern.Mode;
                    dst.OpCode = pattern.OpCode;

                    dst.Index = info.Index;
                    dst.Name = info.Name;
                    dst.Kind = info.Kind;
                    dst.NonTerm = info.IsNonTerminal;
                    dst.Action = info.Action;
                    dst.OpWidth = info.OpWidth;
                    dst.CellType = info.CellType;
                    dst.BitWidth = info.BitWidth;
                    dst.CellWidth = info.CellWidth;
                    dst.RegLit = info.RegLit;
                    dst.Modifier = info.Modifier;
                    dst.Visibility = info.Visibility;
                    dst.NonTerminal = info.NonTerminal;

                    dst.SourceExpr = op.SourceExpr;

                    buffer.Add(dst);
                }
            }

            return buffer.ToArray().Sort();
        }

        public static PatternOpInfo describe(in PatternOp src)
        {
            var dst = PatternOpInfo.Empty;
            dst.Index = src.Index;
            dst.Kind = src.Kind;
            dst.Name = src.Name;
            ref readonly var attribs = ref src.Attribs;
            XedPatterns.nonterm(src, out dst.NonTerminal);

            if(attribs.Search(OpClass.Action, out var a))
                dst.Action = a.AsAction();

            if(src.OpWidth(out dst.OpWidth))
                dst.BitWidth = dst.OpWidth.Bits;

            if(attribs.Search(OpClass.ElementType, out var et))
            {
                dst.CellType = et.AsElementType();
                dst.CellWidth = bitwidth(dst.OpWidth.Code, dst.CellType);
            }
            if(src.RegLiteral(out dst.RegLit))
            {
                dst.BitWidth = bitwidth(dst.RegLit);
            }

            if(attribs.Search(OpClass.Modifier, out var mod))
                dst.Modifier = mod.AsModifier();

            if(attribs.Search(OpClass.Visibility, out var visib))
                dst.Visibility = visib.AsVisibility();

            return dst;
        }
    }
}