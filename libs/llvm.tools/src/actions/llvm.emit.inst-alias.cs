//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/inst-alias")]
        void RunInstAliasQuery(CmdArgs args)
            => AppSvc.TableEmit(DataProvider.InstAliases(), Paths.Table<LlvmInstAlias>());
    }
}