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
            var asmids = DataProvider.AsmIdentifiers().ToItemList();
            var spec = StringTables.spec(
                tableNs: "Z0.llvm",
                tableName: "AsmIdData",
                indexName: "AsmId",
                indexNs: "z0.llvm",
                indexType: ClrIntegerType.U16,
                emitIndex:true
                );
            ItemList<string> items = ("AsmId", asmids.Map(x => new ListItem<string>(x.Key, x.Value.Format())));
            var literals = @readonly(map(DataProvider.AsmIdentifiers().Entries,e => Literals.literal(e.Key, e.Value.Id)));
            var dst = text.buffer();
            CsRender.@enum(0u, "AsmId", literals, dst);
            Write(dst.Emit());
            return true;
        }
    }
}