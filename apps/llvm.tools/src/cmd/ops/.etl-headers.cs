//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".etl-headers")]
        Outcome HeaderEtl(CmdArgs args)
            => LlvmEtl.RunHeaderEtl();
    }
}