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
                    op.OpCode = pattern.OpCode;
                }
            }
            return dst.Sort();
        }

        static void CalcOpProps(in OpSpec spec, ref InstPatternOp op)
        {
            ref readonly var attribs = ref spec.Attribs;
            op.OpIndex = spec.Index;
            op.Name = spec.Name;
            op.Kind = spec.Kind;
            op.Expression = spec.Expression;
            if(attribs.Search(OpClass.Action, out var action))
                op.Action = action;
            if(attribs.Search(OpClass.OpWidth, out var w))
            {
                op.OpWidth = w.AsOpWidth();
                op.BitWidth = op.OpWidth.Bits;
            }
            if(attribs.Search(OpClass.ElementType, out var et))
            {
                op.CellType = et.AsElementType();
                op.CellWidth = bitwidth(op.OpWidth.Code, op.CellType);
            }
            if(attribs.Search(OpClass.RegLiteral, out var reglit))
            {
                op.RegLit = reglit;
                op.BitWidth = bitwidth(reglit.AsRegLiteral());
            }
            if(attribs.Search(OpClass.Modifier, out var mod))
                op.Modifier = mod;
            if(attribs.Search(OpClass.Visibility, out var visib))
                op.Visibility = visib.AsVisibility();
        }
    }
}