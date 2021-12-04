//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames.Queries;
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("llvm/list")]
        Outcome ShowList(CmdArgs args)
            => Flow("list", DataLoader.LoadList(arg(args,0)).Items);

        [CmdOp("llvm/lists")]
        Outcome LoadLists(CmdArgs args)
        {
            var lists = DataLoader.LoadLists().Map(x => x.ToNameList());
            iter(lists, l => Write(l.ListName));
            return true;
        }
    }
}