//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("api/emit/bitmasks")]
        Outcome EmitBitMasks(CmdArgs args)
        {
            var emitted = ApiBitMasks.Emit();

            return true;
        }
    }
}