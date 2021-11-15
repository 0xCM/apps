//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".dump-exe")]
        Outcome DumpExe(CmdArgs args)
            => DumpModules(FileModuleKind.Exe);
    }
}