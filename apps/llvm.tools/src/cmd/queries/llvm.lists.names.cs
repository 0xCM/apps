//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string ListNameQuery = "llvm/lists/names";

        [CmdOp(ListNameQuery)]
        Outcome LoadLists(CmdArgs args)
        {
            Flow(ListNameQuery, DataProvider.SelectLists().Map(x => x.ToNameList()).View);
            return true;
        }
    }
}