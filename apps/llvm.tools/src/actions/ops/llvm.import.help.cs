//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/import/help")]
        Outcome ImportHelp(CmdArgs args)
        {
            DataImporter.ImportToolHelp();
            return true;
        }
    }
}