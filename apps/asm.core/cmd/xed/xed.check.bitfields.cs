//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class AsmCoreCmd
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