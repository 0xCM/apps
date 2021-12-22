//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
            Xed.Rules.Emit(Xed.Rules.ParseEncInstDefs());
            return true;
        }
    }
}