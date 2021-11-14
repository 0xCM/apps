//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".sdm-etl")]
        Outcome ProcessSdm(CmdArgs args)
            => Sdm.RunEtl();
    }
}