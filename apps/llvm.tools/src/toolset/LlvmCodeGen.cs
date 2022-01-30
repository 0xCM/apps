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

        CgSvc CodeGen => Service(Wf.CodeGen);

        const string TargetNs = "Z0.llvm";

        public void Run()
        {
            LlvmPaths.CodeGen().Clear(true);
            EmitStringTables();
            EmitLiteralProviders();
            EmitAsmIds();
        }


        public void EmitAsmIds()
        {
            var asmids = DataProvider.SelectAsmIdentifiers().ToItemList();
            var name = "AsmId";
            ItemList<string> items = (name, asmids.Map(x => new ListItem<string>(x.Key, x.Value.Format())));
            EmitStringTable(TargetNs, ClrEnumKind.U16, items);
            var gen = CodeGen.EnumGen();
            var literals = @readonly(map(DataProvider.SelectAsmIdentifiers().Entries,e => expr.literal(e.Key, e.Value.Id)));
            var buffer = text.buffer();
            var offset = 0u;
            buffer.IndentLineFormat(offset, "namespace {0}", "Z0");
            buffer.IndentLine(offset, Chars.LBrace);
            offset+=4;
            gen.Emit(offset, name, literals, buffer);
            offset-=4;
            buffer.IndentLine(offset, Chars.RBrace);

            var dst = LlvmPaths.CodeGen() + FS.file(name, FS.Cs);
            using var writer = dst.Utf8Writer();
            writer.WriteLine(buffer.Emit());
        }

        public void EmitLiteralProviders()
        {
            var src = DataProvider.SelectAsmMnemonicNames();
            var name = "AsmMnemonicNames";
            var literals = expr.literals(name, src.View, src.View);
            var dst = LlvmPaths.CodeGen() + FS.file(name, FS.Cs);
            CodeGen.LiteralProvider().Emit("Z0", literals, dst);
        }

        public void EmitStringTable(string listid)
        {
            EmitStringTable(DataProvider.SelectList(listid));
        }

        public void EmitStringTable(LlvmList list)
        {
            var path = LlvmPaths.ListImportPath(list.Name);
            EmitStringTable(TargetNs, ClrEnumKind.U32, list.ToItemList());
        }

        public void EmitStringTables()
            => EmitStringTables(DataProvider.SelectLists().Where(x => x.Name != "vcodes"));

        public void EmitStringTables(ReadOnlySpan<LlvmList> src)
        {
            var result = Outcome.Success;
            var count = src.Length;
            var flows = new DataList<Arrow<FS.FileUri>>();
            for(var i=0; i<count; i++)
                EmitStringTable(skip(src,i));
        }

        FS.FilePath OutPath(StringTableSyntax src, FS.FileExt ext)
            => LlvmPaths.StringTablePath("llvm.stringtables." + src.TableName, ext);

        public void EmitStringTable(Identifier targetNs, ClrEnumKind kind, ItemList<string> list)
        {
            var name = list.Name;
            var syntax = StringTables.syntax(targetNs + ".stringtables", name +"ST", name + "Kind", kind, targetNs);
            var table = StringTables.create(syntax, list);
            EmitTableCode(syntax,list);
            EmitTableData(table);
        }

        FS.FileUri EmitTableCode(StringTableSyntax src, ItemList<string> items)
        {
            var dst = OutPath(src, FS.Cs);
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            StringTables.csharp(src, items, writer);
            EmittedFile(emitting,1);
            return dst;
        }

        FS.FileUri EmitTableData(StringTable table)
        {
            var dst = OutPath(table.Syntax, FS.Csv);
            var formatter = Tables.formatter<StringTableRow>(StringTableRow.RenderWidths);
            var emitting = EmittingFile(dst);

            using var writer = dst.AsciWriter();
            writer.WriteLine(formatter.FormatHeader());

            for(var j=0u; j<table.EntryCount; j++)
                writer.WriteLine(formatter.Format(StringTables.row(table, j)));

            EmittedFile(emitting, table.EntryCount);
            return dst;
        }
   }
}