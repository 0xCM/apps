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
        [CmdOp("xed/check/macros")]
        Outcome CheckMacros(CmdArgs args)
        {
            var macros = XedRules.macros().Storage.Map(x => (x.Name, x)).ToDictionary();
            var fields = RuleMachine.fields();
            var patterns = Xed.Rules.CalcPatterns(RuleSetKind.Enc);
            Xed.Rules.ExpandMacros(patterns);
            var buffer = text.buffer();
            for(var i=0; i<patterns.Count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var tokens = ref pattern.Tokens;
                buffer.AppendLine(text.delimit(tokens," | ", -24));

                // for(var j=0; j<tokens.Count; j++)
                // {
                //     ref readonly var token = ref tokens[j];
                //     if(token.Kind == RuleTokenKind.Macro)
                //     {
                //         var macro = token.AsMacro();
                //         Write(macro.Format());
                //     }
                // }
            }
            return true;
        }


        [CmdOp("xed/check/fields")]
        Outcome CheckFields(CmdArgs args)
        {
            var src = RuleMachine.specs();
            TableEmit(src.View, RuleFieldSpec.RenderWidths, AppDb.XedTable<RuleFieldSpec>());
            return true;
        }

        [CmdOp("xed/check/rules/tables")]
        Outcome CheckRuleTables(CmdArgs args)
        {
            var encrules = Xed.Rules.CalcEncRuleTables();
            var encnames = RuleNames(encrules).ToHashSet();
            var calls = Calls(encrules);
            iter(calls, call => Write(call));
            var decrules = Xed.Rules.CalcDecRuleTables();
            var decnames = RuleNames(decrules);
            return true;
        }

        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            XedRuleChecks.create(Wf).CheckRules();
            return true;
        }

        [CmdOp("xed/check/seq")]
        Outcome CheckEncSeq(CmdArgs args)
        {
            XedRuleChecks.create(Wf).CheckRuleSeq();
            return true;
        }

        void ShowTableMacros(Index<RuleTable> tables)
        {
            var count = tables.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var table = ref tables[i];
                ref readonly var expressions = ref table.Expressions;
                for(var j=0; j<expressions.Count; j++)
                {
                    ref readonly var expr = ref expressions[j];
                    ref readonly var premise = ref expr.Premise;
                    ref readonly var consequent = ref expr.Consequent;
                    for(var k0 = 0; k0<premise.Count; k0++)
                    {
                        ref readonly var p = ref premise[k0];
                        if(p.Value.Contains("macro<"))
                        {
                            Write(string.Format("premise: {0}", p));
                        }
                    }

                    for(var k1 = 0; k1<consequent.Count; k1++)
                    {
                        ref readonly var c = ref consequent[k1];
                        if(c.Value.Contains("macro<"))
                        {
                            Write(string.Format("consequent: {0}", c));
                        }
                    }
                }
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