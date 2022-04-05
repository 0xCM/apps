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
        public static Index<RuleGridCells> cells(in RuleTable src)
        {
            var buffer = alloc<RuleGridCells>(src.Body.Count);
            ref readonly var statements = ref src.Body;
            for(var j=0; j<statements.Count; j++)
            {
                var m = z8;
                ref var dst = ref seek(buffer,j);
                ref readonly var left = ref statements[j].Premise;
                for(var k=0; k<left.Count; k++)
                {
                    dst[m] = cell(true, src.Sig, m, left[k]);
                    m++;
                }
                ref readonly var right = ref statements[j].Consequent;
                for(var k=0; k<right.Count; k++)
                {
                    dst[m] = cell(false, src.Sig, m, right[k]);
                    m++;
                }
                dst.Count = m;
            }

            return buffer;
        }
    }
}