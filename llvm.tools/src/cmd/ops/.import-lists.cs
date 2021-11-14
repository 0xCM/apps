//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".import-lists")]
        Outcome ImportLists(CmdArgs args)
        {
            RecordEtl.ImportLists();
            return true;
        }
    }
}