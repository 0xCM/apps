//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".sdm-opcodes")]
        Outcome SdmImport(CmdArgs args)
        {
            var result = Outcome.Success;
            Sdm.ImportOpCodes();
            return result;
        }
    }
}