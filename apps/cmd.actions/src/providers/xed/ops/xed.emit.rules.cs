//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedModels;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/rules")]
        Outcome EmitXedRules(CmdArgs args)
        {
            Xed.Rules.EmitCatalog();
            return true;
        }

    }
}