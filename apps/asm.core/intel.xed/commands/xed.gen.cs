//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedMachine;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/gen")]
        Outcome XedGen(CmdArgs args)
        {
            ref readonly var fields = ref XedLookups.Fields;




            return true;
        }

    }
}