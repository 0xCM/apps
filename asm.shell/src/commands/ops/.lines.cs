//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".lines")]
        Outcome ReadLines(CmdArgs args)
        {
            var result = Outcome.Success;
            return ReadAsciLines();
        }
    }
}