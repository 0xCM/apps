//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static Root;

    partial class LlvmCmd
    {
        [CmdOp("llvm/asm/id")]
        Outcome ListAsmIds(CmdArgs args)
        {
            var asmids = DataProvider.SelectAsmIdentifiers().ToItemList();
            var syntax = StringTables.syntax("Z0.llvm", "AsmIdData", "AsmId", "z0.llvm");
            var spec = StringTables.specify(syntax, asmids.Map(x => new ListItem<string>(x.Key, x.Value.Format())));
            return true;
        }
    }
}