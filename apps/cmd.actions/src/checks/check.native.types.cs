//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CheckCmdProvider
    {
        [CmdOp("check/native/types")]
        Outcome CheckNativeTypes(CmdArgs args)
        {
            var t0 = NativeTypes.seg(NativeSegKind.Seg128x16i);
            Write(t0.Format());

            var t1 = NativeTypes.seg(NativeSegKind.Seg16u);
            Write(t1.Format());


            return true;
        }
    }
}