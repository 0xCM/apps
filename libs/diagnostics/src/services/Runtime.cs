//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using PCK = ProcessContextFlag;

    public partial class Runtime : WfSvc<Runtime>
    {
        IDumpArchive Dumps => DumpArchive.Service;

        ImageRegions Regions => Wf.ImageRegions();

        ProcessMemory ProcessMemory => Wf.ProcessMemory();

        ApiPacks ApiPacks => Wf.ApiPacks();

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
            var details = Regions.EmitRegions(process, ts);
            EmitDump(process, archive.DumpPath(process, ts));
        }

        public void CollectMemStats(Timestamp ts)
        {
            var pipe = Wf.Runtime();
            var flags = ProcessContextFlag.Detail | ProcessContextFlag.Summary | ProcessContextFlag.Hashes;
            var pre = ApiPacks.create(ts,"prejit");
            var prejit = Emit(flags, pre);
            var members = Wf.ApiJit().JitCatalog();
            var post = ApiPacks.create(ts,"prejit");
            var postjit = Emit(flags, post);
        }

        ProcessContext Emit(PCK flag, IApiPack dst)
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
            context.Timestamp = dst.Timestamp;
            context.Subject = dst.Label;
            if(selection.EmitSummary)
            {
                context.PartitionPath = dst.ProcessPartitionPath(process);
                context.Partitions = ProcessMemory.EmitPartitions(process, context.PartitionPath);
            }
            if(selection.EmitDetail)
            {
                context.RegionPath = dst.MemoryRegionPath(process);
                context.Regions = Regions.EmitRegions(process, context.RegionPath);
            }
            if(selection.EmitDump)
            {
                context.DumpPath = Dumps.DumpPath(process, dst.Timestamp);
                EmitDump(process, context.DumpPath);
            }
            if(selection.EmitHashes)
            {
                ProcessMemory.EmitHashes(context, dst);
            }

            Ran(flow,"Emitted process context");
            return context;
        }

        public void EmitProcessContext(IApiPack dst)
        {
            var flow = Running("Emitting process context");
            var process = Process.GetCurrentProcess();
            var procparts = ProcessMemory.EmitPartitions(process, dst.Timestamp, dst.Root);
            var regions = Regions.EmitRegions(process, dst.Timestamp, dst.Root);
            EmitDump(process, dst.ProcDumpPath(process));
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