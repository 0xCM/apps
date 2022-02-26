//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules/tables")]
        Outcome CheckRuleTables(CmdArgs args)
        {
            var decrules = Xed.Rules.ParseDecRuleTables();
            var encrules = Xed.Rules.ParseEncRuleTables();
            var terms = Xed.Rules.Terminals(encrules);
            var nonterms = Xed.Rules.Nonterminals(encrules);

            return true;
        }

    }
}