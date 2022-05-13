//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        PolyBits PolyBits => Service(Wf.PolyBits);


        [CmdOp("pb/check")]
        Outcome CheckBits(CmdArgs args)
        {
            PolyBits.RunChecks();
            return true;
        }
    }
}