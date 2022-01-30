//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/codegen/asmid")]
        Outcome ListAsmIds(CmdArgs args)
        {
            var asmids = DataProvider.SelectAsmIdentifiers().ToItemList();
            var syntax = StringTables.syntax("Z0.llvm", "AsmIdData", "AsmId", ClrEnumKind.U16, "z0.llvm");
            ItemList<string> items = ("AsmId", asmids.Map(x => new ListItem<string>(x.Key, x.Value.Format())));
            var gen = CodeGen.EnumGen();
            var literals = @readonly(map(DataProvider.SelectAsmIdentifiers().Entries,e => expr.literal(e.Key, e.Value.Id)));
            var dst = text.buffer();
            gen.Emit(0u, "AsmId", literals, dst);
            Write(dst.Emit());
            return true;
        }
    }
}