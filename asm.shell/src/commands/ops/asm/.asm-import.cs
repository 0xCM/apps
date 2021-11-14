//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".asm-import")]
        Outcome ImportAsm(CmdArgs args)
            => ImportAsm(arg(args,0));
    }
}