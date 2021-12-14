//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;
    using static Root;

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
            var literals = expr.literals(src.View, src.View);
            var dst = LlvmPaths.CodeGen() + FS.file(name, FS.Cs);
            Generators.LiteralProvider().Emit(TargetNs, name, literals.View, dst);
        }

        public Arrow<FS.FileUri> EmitStringTable(string listid)
        {
            var list = new LlvmList[]{DataProvider.SelectList(listid)};
            var result = EmitStringTables(@readonly(list));
            return first(result);
        }

        public void EmitStringTable(LlvmList list, DataList<Arrow<FS.FileUri>> flows)
        {
            var path = list.Path;
            var name = list.Name;
            var lines = slice(path.ReadLines().Where(l => l.IsNotBlank()).Select(x => text.right(x,Chars.Pipe)).View,1);
            var syntax = StringTables.syntax(TargetNs + ".stringtables", name +"ST", name + "Kind", ClrEnumKind.U32, TargetNs);
            var table = StringTables.create(syntax, list.Values(), list.Identifiers());
            flows.Add(EmitStringTableData(list,table));
            flows.Add(EmitStringTableCode(list,table));
        }

        public ReadOnlySpan<Arrow<FS.FileUri>> EmitStringTables()
            => EmitStringTables(DataProvider.SelectLists().Where(x => x.ListId != "vcodes"));

        public ReadOnlySpan<Arrow<FS.FileUri>> EmitStringTables(ReadOnlySpan<LlvmList> src)
        {
            var result = Outcome.Success;
            var count = src.Length;
            var formatter = Tables.formatter<StringTableRow>(StringTableRow.RenderWidths);
            var flows = new DataList<Arrow<FS.FileUri>>();
            for(var i=0; i<count; i++)
                EmitStringTable(skip(src,i), flows);
            return flows.View();
        }

        FS.FilePath OutPath(StringTable src, FS.FileExt ext)
            => LlvmPaths.StringTablePath("llvm.stringtables." + src.Syntax.TableName, ext);

        Arrow<FS.FileUri> EmitStringTableCode(LlvmList list, StringTable table)
        {
            var dst = OutPath(table,FS.Cs);
            var spec = StringTables.specify(table.Syntax, list.ToItemList());
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            StringTables.csharp(spec, writer);
            EmittedFile(emitting,1);
            return FS.flow(list.Path,dst);
        }

        Arrow<FS.FileUri> EmitStringTableData(LlvmList list, StringTable table)
        {
            var dst = OutPath(table, FS.Csv);
            var formatter = Tables.formatter<StringTableRow>(StringTableRow.RenderWidths);
            var emitting = EmittingFile(dst);

            using var writer = dst.AsciWriter();
            writer.WriteLine(formatter.FormatHeader());

            for(var j=0u; j<table.EntryCount; j++)
                writer.WriteLine(formatter.Format(StringTables.row(table, j)));

            var flow = FS.flow(list.Path,dst);
            EmittedFile(emitting, table.EntryCount, flow);
            return flow;
        }
   }
}