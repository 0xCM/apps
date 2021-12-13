//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string ImportHelpCmd = "llvm/import/help";

        [CmdOp(ImportHelpCmd)]
        Outcome ImportHelp(CmdArgs args)
        {
            DataImporter.ImportToolHelp();
            return true;
        }
    }
}