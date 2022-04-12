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
        public static Index<PatternOpDetail> opdetails(RuleTables tables, Index<InstPattern> src)
        {
            var buffer = list<PatternOpDetail>();
            var lookups = XedLookups.Service;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i];
                ref readonly var ops = ref pattern.Ops;
                var count = (byte)ops.Count;
                for(var j=0; j<count; j++)
                    buffer.Add(opdetail(pattern, count, ops[j]));
            }

            return buffer.ToArray().Sort(new PatternOrder());
        }
    }
}