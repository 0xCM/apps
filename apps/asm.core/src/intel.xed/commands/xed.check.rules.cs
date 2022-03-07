//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRuleSpecs(CmdArgs args)
        {
            var tables = Xed.Rules.CalcRuleTables();
            var sigs = tables.Keys.ToArray().Sort();
            var regs = Xed.CalcRegMap();
            for(var i=0; i<sigs.Length; i++)
            {
                var table = tables[skip(sigs,i)];
                if(table.ComputesRegister)
                {
                    Write(table.Sig);

                    var express = table.Expressions;
                    for(var j=0; j<express.Count; j++)
                    {
                        ref readonly var expr = ref express[j];
                        var criteria = expr.Consequent.Where(x => !x.IsError);
                        for(var k=0; k<criteria.Length; k++)
                        {
                            ref readonly var criterion = ref criteria[k];
                            if(criterion.IsOutReg)
                            {
                                var reg = criterion.AsXedReg();
                                if(reg == 0 || reg == XedRegId.ERROR)
                                    continue;

                                if(regs.Map(reg, out var mapped))
                                {
                                    Write(string.Format("  {0}", mapped));
                                }
                                else
                                {
                                    Warn(string.Format("  {0}", reg));
                                }
                            }
                            else if(criterion.IsNonterminal)
                            {
                                Write(string.Format("  {0}", criterion));
                            }


                            //Write(string.Format("   {0}", criterion.Format()));
                        }
                    }

                }
            }
            return true;
        }
    }
}