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
        public Index<RulePattern> CalcRulePatterns(ReadOnlySpan<InstDef> src)
        {
            var buffer = hashset<RulePattern>();
            var instcount = src.Length;
            for(var i=0; i<instcount; i++)
            {
                ref readonly var inst = ref skip(src,i);
                var operands = inst.PatternSpecs;
                var opcount = operands.Length;
                for(var j=0; j<opcount;j++)
                {
                    ref readonly var op = ref operands[j];
                    var pattern = new RulePattern();
                    pattern.Class = inst.Class;
                    pattern.Hash = alg.hash.marvin(op.PatternExpr.Text);
                    pattern.OpCodeKind = ockind(op.PatternExpr.Text);
                    pattern.Expression = op.PatternExpr;
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

        public Index<RulePattern> CalcRulePatterns(in InstDef inst)
        {
            var buffer = list<RulePattern>();
            CalcRulePatterns(inst, buffer);
            return buffer.ToArray();
        }

        Index<RulePattern> CalcRulePatterns(in InstDef inst, List<RulePattern> buffer)
        {
            var operands = inst.PatternSpecs;
            var opcount = operands.Length;
            for(var j=0; j<opcount;j++)
            {
                ref readonly var op = ref operands[j];
                var pattern = new RulePattern();
                pattern.Class = inst.Class;
                pattern.Hash = alg.hash.marvin(op.PatternExpr.Text);
                pattern.OpCodeKind = ockind(op.PatternExpr.Text);
                pattern.Expression = op.PatternExpr;
                buffer.Add(pattern);
            }
            return buffer.ToArray();
        }
    }
}