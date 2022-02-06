//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
    using static core;

    partial class XedRules
    {
        public Index<XedOpCode> ExtractOpCodes(ReadOnlySpan<RulePattern> src)
        {
            var parser = XedOpCodeParser.create();
            return parser.Parse(src);
        }


        Index<RulePattern> ExtractRulePatterns(ReadOnlySpan<InstDef> src)
        {
            var buffer = hashset<RulePattern>();
            var instcount = src.Length;
            for(var i=0; i<instcount; i++)
            {
                ref readonly var inst = ref skip(src,i);
                var operands = inst.PatternOps;
                var opcount = operands.Length;
                for(var j=0; j<opcount;j++)
                {
                    ref readonly var op = ref operands[j];
                    var pattern = new RulePattern();
                    pattern.Class = inst.Class;
                    pattern.Hash = alg.hash.marvin(op.Expr.Text);
                    pattern.OpCodeKind = OpCodePatterns.kind(op.Expr.Text);
                    pattern.Expression = op.Expr;
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