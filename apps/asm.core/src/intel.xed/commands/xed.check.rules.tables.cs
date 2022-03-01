//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules/tables")]
        Outcome CheckRuleTables(CmdArgs args)
        {
            var encrules = Xed.Rules.ParseEncRuleTables();
            var encnames = RuleNames(encrules).ToHashSet();
            var calls = Calls(encrules);
            iter(calls, call => Write(call));

            var decrules = Xed.Rules.ParseDecRuleTables();
            var decnames = RuleNames(decrules);
            return true;
        }

        Symbols<RuleMacroName> MacroNames {get;} = Symbols.index<RuleMacroName>();


        [CmdOp("xed/check/macros")]
        Outcome CheckRuleMacros(CmdArgs args)
        {

            return true;

        }

        void ExpandMacros(Index<RuleTable> src)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref var table = ref src[i];
                ExpandMacros(ref table);
            }
        }

        void ExpandMacros(ref RuleTable src)
        {
            ref var expressions = ref src.Expressions;
            var count = expressions.Count;
            for(var i=0; i<count; i++)
            {
                ref var expr = ref expressions[i];
                ExpandMacros(ref expr);
            }
        }

        void ExpandMacros(ref XedRuleExpr src)
        {
            ExpandMacros(src.Premise);
            ExpandMacros(src.Consequent);
        }

        void ExpandMacros(Index<RuleCriterion> src)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref var c = ref src[i];
                ExpandMacros(ref c);
            }

        }

        void ExpandMacros(ref RuleCriterion src)
        {
            if(MacroNames.Lookup(src.Value, out var name))
            {

            }

        }

        Index<string> RuleNames(Index<RuleTable> src)
            => src.Select(x => x.Name.Format()).Where(nonempty).Distinct().Sort();

        Index<RuleCall> Calls(Index<RuleTable> src)
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
                if(Calls(table, out var calls))
                {
                    for(var j=0; j<calls.Count; j++)
                    {
                        var source = name;
                        var target = calls[j].Value;
                        var call = new RuleCall(source, target);
                        buffer.Add(call);
                    }
                }
            }

            return buffer.ToArray();
        }

        bool Calls(in RuleTable src, out Index<RuleCriterion> dst)
        {
            var expr = src.Expressions;
            var count = src.Expressions.Count;
            ref readonly var name = ref src.Name;
            var buffer = hashset<RuleCriterion>();
            dst = sys.empty<RuleCriterion>();
            for(var i=0; i<expr.Length; i++)
            {
                ref readonly var x = ref expr[i];
                ref readonly var c = ref x.Consequent;
                for(var j=0; j<c.Count; j++)
                {
                    ref readonly var rc = ref c[j];
                    if(rc.Operator == RuleOperator.Call)
                        buffer.Add(rc);
                }
            }
            if(buffer.Count != 0)
                dst = buffer.ToArray();

            return buffer.Count != 0;
        }
    }
}