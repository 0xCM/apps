//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PbCmd
    {
        [CmdOp("pb/check")]
        Outcome CheckBits(CmdArgs args)
        {
            PolyBits.RunChecks();
            return true;
        }
    }
}