//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("api/emit/bitmasks")]
        Outcome EmitBitMasks(CmdArgs args)
        {
            ApiSvc.EmitBitMasks();
            return true;
        }
    }
}