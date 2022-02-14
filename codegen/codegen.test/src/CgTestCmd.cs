//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using llvm;
    using Asm;
    using static core;

    public sealed partial class CgShellCmd : AppCmdService<CgShellCmd,CmdShellState>
    {
        StringTableChecks LlvmStringTableChecks => Service(() => StringTableChecks.create(Wf));

        [CmdOp("check/asm/strings")]
        Outcome CheckLlvmStringTables(CmdArgs args)
        {
            //LlvmStringTableChecks.Run();

            var strings = AsmSigST.Strings;
            var count = AsmSigST.EntryCount;
            for(var i=0; i<count; i++)
            {
                var kind = (AsmFormKind)i;
                Write(string.Format("{0,-32} | {1}", kind, text.format(strings.Cells(kind))));
            }


            return true;
        }

    }
}
