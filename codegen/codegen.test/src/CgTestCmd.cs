//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using llvm;
    using static core;

    public sealed partial class CgShellCmd : AppCmdService<CgShellCmd,CmdShellState>
    {
        StringTableChecks LlvmStringTableChecks => Service(() => StringTableChecks.create(Wf));

        [CmdOp("llvm/checks/stringtables")]
        Outcome CheckLlvmStringTables(CmdArgs args)
        {
            LlvmStringTableChecks.Run();
            return true;
        }

    }
}
