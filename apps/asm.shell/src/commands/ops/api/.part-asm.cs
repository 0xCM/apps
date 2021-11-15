//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".part-asm")]
        Outcome PartAsmCapture(CmdArgs args)
        {
            var outcome = ApiParsers.part(arg(args,0).Value, out var part);
            if(outcome.Fail)
                return outcome;

            Files(ApiArchive.AsmCapturePaths(part));
            return ReadAsciLines();
        }
    }
}