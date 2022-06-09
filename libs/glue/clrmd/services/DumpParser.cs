//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using Microsoft.Diagnostics.Runtime;

    using DP = DiagnosticProcessors;
    using DR = ClrMdRecords;

    public sealed class DumpParser : AppService<DumpParser>
    {
        DumpArchive Archive => Wf.DumpArchive();

        AppSvcOps AppSvc => Wf.AppSvc();

        public DumpParser()
        {

        }

        void Emit(ProcDumpName id, ReadOnlySpan<DR.ModuleInfo> src)
            => AppSvc.TableEmit(src, Archive.Table<DR.ModuleInfo>(id));

        ExecToken Emit(ProcDumpName id, ReadOnlySpan<DR.MethodTableToken> src)
            => AppSvc.TableEmit(src, Archive.Table<DR.MethodTableToken>(id));

        void Emit(ProcDumpName id, DP.ModuleProcessPresult src)
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
                var sink = EmissionSink.create(GetType());
                var processor = DP.module(sink);
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