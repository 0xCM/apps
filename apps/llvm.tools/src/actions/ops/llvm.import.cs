//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/import")]
        Outcome RunRecordsEtl(CmdArgs args)
        {
            Importer.Run();
            return true;
        }
    }
}