//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public class LlvmCodeGen : AppService<LlvmCodeGen>
    {
        LlvmPaths LlvmPaths;

        OmniScript OmniScript;

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            OmniScript = Wf.OmniScript();
        }

        public void Run(in EtlDatasets src)
        {
            LlvmPaths.CodeGen().Clear(true);
            GenStringTables();
        }

        Outcome GenStringTables()
        {
            const string BaseId = "llvm.stringtables";
            var result = Outcome.Success;
            var lists = LlvmPaths.ListSourceFiles().View;
            var count = lists.Length;
            var formatter = Tables.formatter<StringTableRow>(StringTableRow.RenderWidths);
            var rowcount = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var listpath = ref skip(lists,i);
                var name = listpath.FileName.WithoutExtension.Format();
                var id = BaseId + "." + name;
                var cspath = LlvmPaths.CodeGenPath(id, FS.Cs);
                var csvpath = LlvmPaths.CodeGenPath(id, FS.Csv);
                var lines = listpath.ReadLines().View;
                var table = StringTables.create(lines, name, Chars.Comma);
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

                EmittedFile(csEmitting, count,FS.flow(listpath,cspath));
                EmittedFile(rowEmitting,rowcount,FS.flow(listpath,csvpath));
            }

            return result;
        }
    }
}