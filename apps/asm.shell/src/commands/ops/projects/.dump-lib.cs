//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".dump-lib")]
        Outcome DumpLib(CmdArgs args)
            => DumpModules(FileModuleKind.Lib);
    }
}