//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{

    using static core;

    partial class LlvmCmdProvider
    {
        const string InstAliasQuery = "llvm/emit/inst-alias";

        [CmdOp(InstAliasQuery)]
        Outcome RunInstAliasQuery(CmdArgs args)
        {
            TableEmit(DataProvider.SelectInstAliases().View, LlvmInstAlias.RenderWidths, LlvmPaths.Table<LlvmInstAlias>());
            return true;
        }
    }
}