//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/bitfields")]
        Outcome CheckBitfields(CmdArgs args)
        {
            var bf = RuleFieldBits.create();
            Write(bf.Dataset.Intervals.Format());
            return true;
        }
    }
}