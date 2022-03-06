//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules/tables")]
        Outcome CheckRuleTables(CmdArgs args)
        {
            iter(Calls(Xed.Rules.CalcEncRuleTables()), call => Write(call));
            iter(Calls(Xed.Rules.CalcDecRuleTables()), call => Write(call));
            iter(Calls(Xed.Rules.CalcEncDecRuleTables()), call => Write(call));
            return true;
        }

        Index<RuleCall> Calls(Index<RuleTermTable> src)
        {
            var count = src.Count;
            var dst = text.buffer();
            var buffer = list<RuleCall>();
            for(var i=0; i<count; i++)
            {
                ref readonly var table = ref src[i];
                ref readonly var name = ref table.Name;
                var sig = table.Sig;
                dst.AppendLine(sig);
                var expr = table.Expressions;
                if(calls(table, out var result))
                {
                    for(var j=0; j<result.Count; j++)
                    {
                        var source = name;
                        var target = result[j].Value;
                        var call = new RuleCall(source, target);
                        buffer.Add(call);
                    }
                }
            }

            return buffer.ToArray();
        }

        static bool calls(in RuleTermTable src, out Index<RuleTerm> dst)
        {
            var expr = src.Expressions;
            var count = src.Expressions.Count;
            ref readonly var name = ref src.Name;
            var buffer = hashset<RuleTerm>();
            dst = sys.empty<RuleTerm>();
            for(var i=0; i<expr.Length; i++)
            {
                ref readonly var x = ref expr[i];
                ref readonly var c = ref x.Consequent;
                // for(var j=0; j<c.Count; j++)
                // {
                //     ref readonly var rc = ref c[j];
                //     if(rc.Operator == RuleOperator.Call)
                //         buffer.Add(rc);
                // }
            }
            if(buffer.Count != 0)
                dst = buffer.ToArray();

            return buffer.Count != 0;
        }
    }
}