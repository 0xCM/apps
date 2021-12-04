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
        LlvmPaths LlvmPaths;

        OmniScript OmniScript;

        LlvmDataLoader TableLoader;

        Generators Generators;

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            OmniScript = Wf.OmniScript();
            TableLoader = LlvmDataLoader.create(Wf);
            Generators = Wf.Generators();
        }

        public void Run()
        {
            LlvmPaths.CodeGen().Clear(true);
            GenStringTables();
            GenLiteralProviders();
        }

        void GenLiteralProviders()
        {
            var src = TableLoader.LoadAsmMnemonicNames();
            var literals = expr.literals(src.View, src.View);
            var dst = Generators.CodeGenPath("llvm", "AsmMnemonicNames", FS.Cs);
            Generators.LiteralProvider().Emit("Z0.llvm", "AsmMnemonicNames", literals, dst);
        }

        public Arrow<FS.FileUri> GenStringTable(string listid)
        {
            var list = new LlvmList[]{TableLoader.LoadList(listid)};
            var result = GenStringTables(@readonly(list));
            return first(result);
        }

        public ReadOnlySpan<Arrow<FS.FileUri>> GenStringTables(ReadOnlySpan<LlvmList> src)
        {
            const string BaseTargetId = "llvm.stringtables";
            const string TargetNs = "Z0";
            const string BaseSourceId = "llvm.lists";
            var result = Outcome.Success;
            var lists = src;
            var count = src.Length;
            var formatter = Tables.formatter<StringTableRow>(StringTableRow.RenderWidths);
            var rowcount = 0u;
            var flows = list<Arrow<FS.FileUri>>();

            for(var i=0; i<count; i++)
            {
                ref readonly var list = ref skip(lists,i);
                var path = list.Path;
                var name = path.FileName.WithoutExtension.Format().Replace(BaseSourceId + ".", EmptyString);
                var id = BaseTargetId + "." + name;
                var cspath = LlvmPaths.StringTablePath(id, FS.Cs);
                var csvpath = LlvmPaths.StringTablePath(id, FS.Csv);
                var lines = slice(path.ReadLines().Where(l => l.IsNotBlank()).Select(x => text.right(x,Chars.Pipe)).View,1);
                var table = StringTables.create(lines, name, Chars.Comma);
                var spec = StringTables.specify(TargetNs + "." + BaseTargetId, table);

                var csEmitting = EmittingFile(cspath);
                var rowEmitting = EmittingFile(csvpath);

                using var cswriter = cspath.Writer();
                using var rowwriter = csvpath.AsciWriter();
                rowwriter.WriteLine(formatter.FormatHeader());

                StringTables.csharp(spec, cswriter);
                for(var j=0u; j<table.EntryCount; j++)
                    rowwriter.WriteLine(formatter.Format(StringTables.row(table, j)));
                rowcount += table.EntryCount;

                var csflow = FS.flow(path,cspath);
                flows.Add(csflow);
                var csvflow = FS.flow(path,csvpath);
                flows.Add(csvflow);

                EmittedFile(csEmitting, count, csflow);
                EmittedFile(rowEmitting, rowcount, csvflow);
            }
            return flows.ViewDeposited();
        }

        static string listid(FS.FilePath src)
            => src.FileName.WithoutExtension.Format().Replace("llvm.lists.", EmptyString);

        Outcome GenStringTables()
        {
            const string BaseId = "llvm.stringtables";
            var exclusions = hashset("vcodes");
            var result = Outcome.Success;
            var lists = LlvmPaths.Lists().View;
            var count = lists.Length;
            var formatter = Tables.formatter<StringTableRow>(StringTableRow.RenderWidths);
            var rowcount = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var listpath = ref skip(lists,i);
                var id = listid(listpath);
                if(exclusions.Contains(id))
                    continue;

                var name = BaseId + "." + id;
                var cspath = LlvmPaths.StringTablePath(name, FS.Cs);
                var csvpath = LlvmPaths.StringTablePath(name, FS.Csv);
                var lines = slice(listpath.ReadLines().Where(l => l.IsNotBlank()).Select(x => text.right(x,Chars.Pipe)).View,1);
                var table = StringTables.create(lines, id, Chars.Comma);
                var spec = StringTables.specify("Z0." + BaseId, table);

                var csEmitting = EmittingFile(cspath);
                var rowEmitting = EmittingFile(csvpath);

                using var cswriter = cspath.Writer();
                using var rowwriter = csvpath.AsciWriter();
                rowwriter.WriteLine(formatter.FormatHeader());

                StringTables.csharp(spec, cswriter);
                for(var j=0u; j<table.EntryCount; j++)
                    rowwriter.WriteLine(formatter.Format(StringTables.row(table, j)));
                rowcount += table.EntryCount;

                EmittedFile(csEmitting, count, FS.flow(listpath,cspath));
                EmittedFile(rowEmitting,rowcount, FS.flow(listpath,csvpath));
            }

            return result;
        }
    }
}