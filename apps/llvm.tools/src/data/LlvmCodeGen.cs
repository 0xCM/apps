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

        Generators Generators => Service(Wf.Generators);

        const string TargetNs = "Z0.llvm";

        public void Run()
        {
            LlvmPaths.CodeGen().Clear(true);
            EmitStringTables();
            EmitLiteralProviders();
        }

        public void EmitLiteralProviders()
        {
            var src = DataProvider.SelectAsmMnemonicNames();
            var name = "AsmMnemonicNames";
            var literals = expr.literals(name, src.View, src.View);
            var dst = LlvmPaths.CodeGen() + FS.file(name, FS.Cs);
            Generators.LiteralProvider().Emit(TargetNs, literals, dst);
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