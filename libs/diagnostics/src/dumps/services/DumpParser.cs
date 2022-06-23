//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using Microsoft.Diagnostics.Runtime;

    using DR = ClrMdRecords;

    public sealed class DumpParser : WfSvc<DumpParser>
    {
        DumpArchive Archive => Wf.DumpArchive();

        public DumpParser()
        {

        }

        void Emit(ProcDumpName id, ReadOnlySpan<DR.ModuleInfo> src)
            => TableEmit(src, Archive.Table<DR.ModuleInfo>(id));

        ExecToken Emit(ProcDumpName id, ReadOnlySpan<DR.MethodTableToken> src)
            => TableEmit(src, Archive.Table<DR.MethodTableToken>(id));

        void Emit(ProcDumpName id, ModuleProcessPresult src)
        {
            Emit(id, src.Modules);
            Emit(id, src.MethodTables);
        }

        public void ParseDump(FS.FilePath src)
        {
            using var dataTarget = DataTarget.LoadDump(src.Name);
            using var runtime = dataTarget.ClrVersions.Single().CreateRuntime();
            var id = ProcDumpName.from(src);
            if(id.IsNonEmpty)
            {
                var running = Running(string.Format("Parsing {0}", src.ToUri()));
                var modules = runtime.EnumerateModules().Array();
                var processor = ModuleProcessor.create(Events.sink());
                processor.Process(modules);
                Emit(id, processor.Processed());
                Ran(running, string.Format("Parsed {0}", src.ToUri()));
            }
            else
            {
                Error(string.Format("Could not identify {0}", src.ToUri()));
            }
        }
    }
}