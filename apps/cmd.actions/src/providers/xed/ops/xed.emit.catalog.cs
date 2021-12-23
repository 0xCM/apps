//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/catalog")]
        protected Outcome EmitXedCat(CmdArgs args)
        {
            Xed.EmitCatalog();
           return true;
        }

        [CmdOp("xed/emit/rules")]
        protected Outcome EmitXedRules(CmdArgs args)
        {
            Xed.Rules.EmitEncInstDefs(Xed.Rules.ParseEncInstDefs());
            Xed.Rules.EmitDecInstDefs(Xed.Rules.ParseDecInstDefs());
            Xed.Rules.EmitEncRuleTables(Xed.Rules.ParseEncRuleTables());
            Xed.Rules.EmitDecRuleTables(Xed.Rules.ParseDecRuleTables());
            return true;
        }
    }
}