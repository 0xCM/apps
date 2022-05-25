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
        DumpArchives DumpArchives => Wf.DumpArchives();

        DumpPaths DumpPaths => DumpArchives.DumpPaths();

        AppSvcOps AppSvc => Wf.AppSvc();

        public DumpParser()
        {

        }

        public void ParseDump()
        {
            var current = DumpPaths.Current();
            if(current.IsNonEmpty)
            {
                var flow = Running(string.Format("Parsing dump {0}", current.FileName));
                ParseDump(current);
                Ran(flow);
            }
            else
                Warn(string.Format("No *.{0} files were found in {1}", FS.Dmp, DumpPaths.InputRoot.Format(PathSeparator.FS)));
        }

        void Emit(ProcDumpIdentity id, ReadOnlySpan<DR.ModuleInfo> src, FS.FolderPath dir)
            => AppSvc.TableEmit(src, Db.Table<DR.ModuleInfo>(dir));

        ExecToken Emit(ProcDumpIdentity id, ReadOnlySpan<DR.MethodTableToken> src, FS.FolderPath dir)
            => AppSvc.TableEmit(src, Db.Table<DR.MethodTableToken>(dir));

        void Emit(ProcDumpIdentity id, DP.ModuleProcessPresult src)
        {
            var dst = DumpPaths.Targets(id);
            Emit(id, src.Modules, dst);
            Emit(id, src.MethodTables, dst);
        }

        public void ParseDump(FS.FilePath src)
        {
            using var dataTarget = DataTarget.LoadDump(src.Name);
            using var runtime = dataTarget.ClrVersions.Single().CreateRuntime();
            var id = ProcDumpIdentity.from(src);
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