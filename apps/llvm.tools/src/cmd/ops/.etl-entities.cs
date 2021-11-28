//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".etl-entities")]
        Outcome RunEntityEtl(CmdArgs args)
            => LlvmEtl.RunEntityEtl();
    }
}