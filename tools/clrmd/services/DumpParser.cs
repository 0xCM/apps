//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using Microsoft.Diagnostics.Runtime;

    using DP = DiagnosticProcessors;
    using DR = DiagnosticRecords;

    public sealed class DumpParser : AppService<DumpParser>
    {
        DumpPaths DumpPaths;

        public DumpParser()
        {

        }

        protected override void OnInit()
        {
            DumpPaths = Db.DumpPaths();
        }

        public void ParseDump()
        {
            var current = DumpPaths.CurrentDump();
            if(current.IsNonEmpty)
            {
                var flow = Wf.Running(string.Format("Parsing dump {0}", current.FileName));
                ParseDump(current);
                Wf.Ran(flow);
            }
            else
                Wf.Warn(string.Format("No *.{0} files were found in {1}", FS.Dmp, DumpPaths.InputRoot.Format(PathSeparator.FS)));
        }

        uint Emit(ProcDumpIdentity id, ReadOnlySpan<DR.ModuleInfo> src, FS.FolderPath dir)
            => TableEmit(src, DR.ModuleInfo.RenderWidths, Db.Table<DR.ModuleInfo>(dir));

        uint Emit(ProcDumpIdentity id, ReadOnlySpan<DR.MethodTableToken> src, FS.FolderPath dir)
            => TableEmit(src, Db.Table<DR.MethodTableToken>(dir));

        void Emit(ProcDumpIdentity id, DP.ModuleProcessPresult src)
        {
            var dst = DumpPaths.OutputDir(id);
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
                var running = Wf.Running(string.Format("Parsing {0}", src.ToUri()));
                var modules = runtime.EnumerateModules().Array();
                var sink = EmissionSink.create(GetType());
                var processor = DP.module(sink);
                processor.Process(modules);
                Emit(id, processor.Processed());

                Wf.Ran(running, string.Format("Parsed {0}", src.ToUri()));
            }
            else
            {
                Wf.Error(string.Format("Could not identify {0}", src.ToUri()));
            }
        }
    }
}