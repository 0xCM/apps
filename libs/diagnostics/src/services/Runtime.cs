//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using PCK = ProcessContextFlag;

    public partial class Runtime : WfSvc<Runtime>
    {
        DumpArchive Dumps => Wf.DumpArchive();

        ProcessMemory ProcessMemory => Wf.ProcessMemory();

        public ProcessTargets ContextPaths {get; private set;}

        protected override void OnInit()
        {
            ContextPaths = new ProcessTargets(AppDb.DbCapture().Root);
        }

        public void EmitContext(Timestamp ts)
        {
            var archive = Dumps;
            var process = Process.GetCurrentProcess();
            var summaries = ProcessMemory.EmitPartitions(process, ts);
            var details = ProcessMemory.EmitRegions(process, ts);
            EmitDump(process, archive.DumpPath(process, ts));
        }

        void CollectMemStats()
        {
            var dst = Db.ProcessContextRoot();
            var pipe = Wf.Runtime();
            var ts = core.timestamp();
            var flags = ProcessContextFlag.Detail | ProcessContextFlag.Summary | ProcessContextFlag.Hashes;
            var prejit = pipe.Emit(ts, "prejit", flags);
            var members = Wf.ApiJit().JitCatalog();
            var postjit = pipe.Emit(ts, "postjit", flags);
        }

        ProcessContext Emit(Timestamp ts, string label = default, PCK flag = PCK.All)
        {
            var selection = ImageMemory.flags(flag);
            if(selection.IsEmpty)
            {
                Warn("No options have been specified");
                return default;
            }

            var flow = Running(string.Format("Emitting process context with options {0}", flag));
            var context = new ProcessContext();
            var process = Process.GetCurrentProcess();
            var name = process.ProcessName;
            context.ProcessId = process.Id;
            context.ProcessName = process.ProcessName;
            context.Timestamp = ts;
            context.Subject = label;
            if(selection.EmitSummary)
            {
                context.PartitionPath = ContextPaths.ProcessPartitionPath(process, ts);
                context.Partitions = ProcessMemory.EmitPartitions(process, context.PartitionPath);
            }
            if(selection.EmitDetail)
            {
                context.RegionPath = ContextPaths.MemoryRegionPath(process, ts);
                context.Regions = ProcessMemory.EmitRegions(process, context.RegionPath);
            }
            if(selection.EmitDump)
            {
                context.DumpPath = Dumps.DumpPath(process, ts);
                EmitDump(process, context.DumpPath);
            }
            if(selection.EmitHashes)
            {
                ProcessMemory.EmitHashes(context, ContextPaths.Root);
            }

            Ran(flow,"Emitted process context");
            return context;
        }

        public void EmitProcessContext(IApiPack pack)
        {
            var flow = Running("Emitting process context");
            var ts = pack.Timestamp;
            var dst = pack.Archive().ContextRoot();
            var process = Process.GetCurrentProcess();
            var procparts = ProcessMemory.EmitPartitions(process, ts, dst.Root);
            var regions = ProcessMemory.EmitRegions(process, ts, dst.Root);
            EmitDump(process, pack.ProcDumpPath(process));
            Ran(flow);
        }

        public Count EmitDump(Process process, FS.FilePath dst)
        {
            var dumping = EmittingFile(dst.CreateParentIfMissing());
            DumpEmitter.emit(process, dst.Format(PathSeparator.BS), DumpTypeOption.Full);
            EmittedFile(dumping,1);
            return 1;
        }
   }
}