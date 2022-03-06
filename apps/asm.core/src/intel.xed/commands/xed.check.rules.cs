//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    using F = XedFormatters;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var rules = Xed.Rules.ExpandMacros(Xed.Rules.CalcRuleSet(RuleSetKind.EncDec));
            void Traversed(string src)
            {
                Write(src);
            }
            var traverser = new RuleTraverserX(Traversed);
            traverser.Traverse(rules);
            var tables = traverser.Tables;
            var sigs = tables.Keys;
            var count = sigs.Length;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var sig = ref skip(sigs,i);
                Write(string.Format("{0}()", sig.Name));
                var rows = tables[sig];

                for(var j=0; j<rows.Count; j++)
                {
                    ref readonly var row = ref rows[j];

                    for(var k=0; k <row.Premise.Count; k++)
                    {
                        ref readonly var c = ref row.Premise[k];
                        if(k != 0)
                            buffer.Append(" && ");

                        if(c.Field == 0)
                            buffer.AppendFormat("<{0}>", c.Value);
                        else
                            buffer.Append(string.Format("{0}{1}{2}", c.Field, F.format(c.Operator), c.Value));
                    }
                    buffer.Append(" <=> ");
                    for(var k=0; k < row.Consequent.Count; k++)
                    {
                        if(k != 0)
                            buffer.Append(" && ");

                        ref readonly var c = ref row.Consequent[k];
                        if(c.Field == 0)
                            buffer.AppendFormat("<{0}>", c.Value);
                        else
                            buffer.Append(string.Format("{0}{1}{2}", c.Field, F.format(c.Operator), c.Value));
                    }

                    Write(string.Format("    {0}", buffer.Emit()));
                }

                Write(EmptyString);
            }

            return true;
        }
    }
}