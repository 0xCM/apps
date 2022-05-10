//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("bits/check")]
        Outcome CheckBits(CmdArgs args)
        {
            BitCheckers.run();
            return true;
        }
    }
}