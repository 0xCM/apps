//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".intel-intrinsics")]
        Outcome EmitIntelIntrinsics(CmdArgs args)
        {
            IntelIntrinsics.Emit();
            return true;
        }
    }
}