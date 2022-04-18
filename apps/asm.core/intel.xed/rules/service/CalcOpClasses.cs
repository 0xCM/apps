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
        public Index<InstOpClass> CalcOpClasses(RuleTables rules, Index<InstPattern> patterns)
            => CalcOpClasses(CalcInstOpDetails(rules,patterns));

        public Index<InstOpClass> CalcOpClasses(Index<InstOpDetail> src)
        {
            return Data(nameof(CalcOpClasses),Calc);

            Index<InstOpClass> Calc()
            {
                var buffer = bag<InstOpClass>();
                iter(src, op => buffer.Add(opclass(op)), true);
                var dst = buffer.Array().Distinct().Sort();
                for(var i=0u; i<dst.Length; i++)
                    seek(dst,i).Seq = i;
                return dst;
            }
        }
    }
}