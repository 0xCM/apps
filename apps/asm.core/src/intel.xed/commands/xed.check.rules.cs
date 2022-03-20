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



            return true;
        }
    }
}