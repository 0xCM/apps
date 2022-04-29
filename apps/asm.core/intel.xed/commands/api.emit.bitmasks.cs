//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedCmdProvider
    {
        BitMaskServices ApiBitMasks => Service(Wf.ApiBitMasks);

        [CmdOp("api/emit/bitmasks")]
        Outcome EmitBitMasks(CmdArgs args)
        {
            var emitted = ApiBitMasks.Emit();

            return true;
        }

    }
}