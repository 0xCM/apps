//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    public class LlvmCodeGen : AppService<LlvmCodeGen>
    {
        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        CsLang CsLang => Service(Wf.CsLang);

        const string TargetNs = "Z0.llvm.strings";

        public void Run()
        {
            LlvmPaths.CodeGen().Clear(true);
            EmitStringTables();
            EmitAsmIds();
        }

        public void EmitAsmIds()
        {
            var asmids = DataProvider.AsmIdentifiers().ToItemList();
            var name = "AsmId";
            ItemList<string> items = (name, asmids.Map(x => new ListItem<string>(x.Key, x.Value.Format())));
            CsLang.GenStringTable(TargetNs, ClrEnumKind.U16, items, CgTarget.Llvm);
            var literals = @readonly(map(DataProvider.AsmIdentifiers().Entries,e => Literals.define(e.Key, e.Value.Id)));
            var buffer = text.buffer();
            var offset = 0u;
            buffer.IndentLineFormat(offset, "namespace {0}", "Z0");
            buffer.IndentLine(offset, Chars.LBrace);
            offset+=4;
            CsRender.@enum(offset, name, literals, buffer);
            offset-=4;
            buffer.IndentLine(offset, Chars.RBrace);

            var dst = LlvmPaths.CodeGen() + FS.file(name, FS.Cs);
            using var writer = dst.Utf8Writer();
            writer.WriteLine(buffer.Emit());
        }

        public void EmitStringTable(LlvmList src)
        {
            var path = LlvmPaths.ListImportPath(src.Name);
            CsLang.GenStringTable(TargetNs, ClrEnumKind.U32, src.ToItemList(), CgTarget.Llvm);
        }

        public void EmitStringTables()
            => EmitStringTables(DataProvider.Lists().Where(x => x.Name != "vcodes"));

        public void EmitStringTables(ReadOnlySpan<LlvmList> src)
        {
            var result = Outcome.Success;
            var count = src.Length;
            var flows = new DataList<Arrow<FS.FileUri>>();
            for(var i=0; i<count; i++)
                EmitStringTable(skip(src,i));
        }
   }
}