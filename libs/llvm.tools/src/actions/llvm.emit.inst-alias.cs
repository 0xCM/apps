//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        [CmdOp("llvm/emit/inst-alias")]
        void RunInstAliasQuery(CmdArgs args)
            => AppSvc.TableEmit(DataProvider.InstAliases(), LlvmPaths.Table<LlvmInstAlias>());
    }
}