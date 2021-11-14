//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".tables")]
        Outcome ListTables(CmdArgs args)
        {
            var outcome = Outcome.Success;
            var dir = Ws.Tables().Root;
            if(args.Count == 0)
                Files(dir.Files(FS.Csv, true));
            else
                Files(dir.Files(arg(args,0).Value, FS.Csv, true));
            return outcome;
        }
    }
}