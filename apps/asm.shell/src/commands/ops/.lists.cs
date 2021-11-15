//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".lists")]
        Outcome ListFiles(CmdArgs args)
        {
            var result = Outcome.Success;
            Files(Ws.Sources().Files(FS.List));
            return result;
        }
    }
}