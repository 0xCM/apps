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
        Index<RulePatternInfo> CalcPatternInfo(ReadOnlySpan<InstDef> src)
        {
            var buffer = hashset<RulePatternInfo>();
            var instcount = src.Length;
            for(var i=0; i<instcount; i++)
            {
                ref readonly var def = ref skip(src,i);
                var operands = def.PatternSpecs;
                var opcount = operands.Length;
                for(var j=0; j<opcount;j++)
                {
                    ref readonly var op = ref operands[j];
                    var pattern = new RulePatternInfo();
                    pattern.Class = def.Class;
                    pattern.InstId = def.Seq;
                    pattern.Hash = alg.hash.marvin(op.BodyExpr.Text);
                    pattern.OpCodeKind = ockind(op.BodyExpr.Text);
                    pattern.BodyExpr = op.BodyExpr;
                    buffer.Add(pattern);
                }
            }

            var dst = buffer.Array().Sort();
            var count = dst.Length;
            var hashes = hashset<Hash32>();
            for(var i=0u; i<count; i++)
            {
                ref var record = ref seek(dst,i);
                record.Seq = i;
                hashes.Add(record.Hash);
            }

            if(hashes.Count != count)
                Warn(string.Format("Rule hash imperfect"));
            else
                Status(string.Format("Rule hash perfect"));

            return dst;
        }

   }
}