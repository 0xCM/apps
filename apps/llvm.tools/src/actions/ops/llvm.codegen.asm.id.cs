//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/codegen/asm/id")]
        Outcome ListAsmIds(CmdArgs args)
        {
            var asmids = DataProvider.SelectAsmIdentifiers().ToItemList();
            var syntax = StringTables.syntax("Z0.llvm", "AsmIdData", "AsmId", "z0.llvm");
            var items = asmids.Map(x => new ListItem<string>(x.Key, x.Value.Format()));
            return true;
        }
    }
}