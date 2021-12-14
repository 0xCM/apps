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

        public void Run()
        {
            LlvmPaths.CodeGen().Clear(true);
            GenStringTables();
            GenLiteralProviders();
        }

        void GenLiteralProviders()
        {
            var src = DataProvider.SelectAsmMnemonicNames();
            var name = "AsmMnemonicNames";
            var literals = expr.literals(src.View, src.View);
            var dst = LlvmPaths.CodeGen() + FS.file(name, FS.Cs);
            Generators.LiteralProvider().Emit("Z0.llvm", name, literals, dst);
        }

        public Arrow<FS.FileUri> GenStringTable(string listid)
        {
            var list = new LlvmList[]{DataProvider.SelectList(listid)};
            var result = GenStringTables(@readonly(list));
            return first(result);
        }

        Arrow<FS.FileUri> EmitStringTableCode(LlvmList list, StringTable table)
        {
            const string BaseTargetId = "llvm.stringtables";
            const string TargetNs = "Z0";
            const string BaseSourceId = "llvm.lists";

            var items = list.ToItemList();
            var name = list.Path.FileName.WithoutExtension.Format().Replace(BaseSourceId + ".", EmptyString);
            var id = BaseTargetId + "." + items.Name;
            var dst = LlvmPaths.StringTablePath(id, FS.Cs);
            var idxname = items.Name + "Kind";
            //var spec = StringTables.specify(TargetNs + "." + BaseTargetId, idxname, true, table);
            var spec = StringTables.specify(table.Syntax, items);

            var emitting = EmittingFile(dst);

            using var writer = dst.Writer();
            StringTables.csharp(spec, writer);
            EmittedFile(emitting,1);

            return FS.flow(list.Path,dst);
        }

        Arrow<FS.FileUri> EmitStringTableData(LlvmList list, StringTable table)
        {
            const string BaseTargetId = "llvm.stringtables";
            const string TargetNs = "Z0";
            const string BaseSourceId = "llvm.lists";

            var name = list.Path.FileName.WithoutExtension.Format().Replace(BaseSourceId + ".", EmptyString);
            var id = BaseTargetId + "." + name;
            var dst = LlvmPaths.StringTablePath(id, FS.Csv);
            var formatter = Tables.formatter<StringTableRow>(StringTableRow.RenderWidths);

            var emitting = EmittingFile(dst);

            using var rowwriter = dst.AsciWriter();
            rowwriter.WriteLine(formatter.FormatHeader());

            for(var j=0u; j<table.EntryCount; j++)
                rowwriter.WriteLine(formatter.Format(StringTables.row(table, j)));

            var flow = FS.flow(list.Path,dst);
            EmittedFile(emitting, table.EntryCount, flow);
            return flow;
        }

        public void GenStringTable(LlvmList list, DataList<Arrow<FS.FileUri>> flows)
        {
            const string BaseTargetId = "llvm.stringtables";
            const string TargetNs = "Z0";
            const string BaseSourceId = "llvm.lists";

            var path = list.Path;
            var name = path.FileName.WithoutExtension.Format().Replace(BaseSourceId + ".", EmptyString);
            var id = BaseTargetId + "." + name;
            var cspath = LlvmPaths.StringTablePath(id, FS.Cs);
            var csvpath = LlvmPaths.StringTablePath(id, FS.Csv);
            var lines = slice(path.ReadLines().Where(l => l.IsNotBlank()).Select(x => text.right(x,Chars.Pipe)).View,1);
            var syntax = StringTables.syntax("Z0.llvm", name +"Data", name + "Kind", ClrEnumKind.U32, true);
            var table = StringTables.create(syntax, list.Values(), list.Identifiers());
            flows.Add(EmitStringTableData(list,table));
            flows.Add(EmitStringTableCode(list,table));
        }

        public ReadOnlySpan<Arrow<FS.FileUri>> GenStringTables()
            => GenStringTables(DataProvider.SelectLists().Where(x => x.ListId != "vcodes"));

        public ReadOnlySpan<Arrow<FS.FileUri>> GenStringTables(ReadOnlySpan<LlvmList> src)
        {
            const string BaseTargetId = "llvm.stringtables";
            const string TargetNs = "Z0";
            const string BaseSourceId = "llvm.lists";
            var result = Outcome.Success;
            var count = src.Length;
            var formatter = Tables.formatter<StringTableRow>(StringTableRow.RenderWidths);
            var flows = new DataList<Arrow<FS.FileUri>>();

            for(var i=0; i<count; i++)
                GenStringTable(skip(src,i), flows);
            return flows.View();
        }
    }
}