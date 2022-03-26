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
        public static Index<InstPatternOp> CalcOpRecords(Index<InstPattern> src)
        {
            var count = 0u;
            iter(src, pattern => count += pattern.OpSpecs.Count);
            var dst = alloc<InstPatternOp>(count);
            var k = 0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i];
                ref readonly var specs = ref pattern.OpSpecs;
                for(var j=0; j<specs.Count; j++, k++)
                {
                    ref var op = ref seek(dst,k);
                    CalcOpProps(specs[j], ref seek(dst,k));
                    op.InstId = pattern.InstId;
                    op.PatternId = pattern.PatternId;
                    op.InstClass = pattern.InstClass;
                    op.Mode = pattern.Mode;
                    op.OpCode = pattern.OpCode;
                }
            }
            return dst.Sort();
        }

        static void CalcOpProps(in OpSpec src, ref InstPatternOp dst)
        {
            ref readonly var attribs = ref src.Attribs;
            dst.Index = src.Index;
            dst.Name = src.Name;
            dst.Kind = src.Kind;
            dst.Expression = src.Expression;
            dst.NonTerm = (bit)XedFields.nonterm(attribs, out dst.NonTerminal);
            attribs.Search(OpClass.Action, out dst.Action);
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
                dst.RegLit = reglit;
                dst.BitWidth = bitwidth(reglit.AsRegLiteral());
            }
            attribs.Search(OpClass.Modifier, out dst.Modifier);

            if(attribs.Search(OpClass.Visibility, out var visib))
                dst.Visibility = visib.AsVisibility();
        }
    }
}