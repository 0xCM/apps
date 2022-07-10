//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class Runtime : WfSvc<Runtime>
    {
        ImageRegions Regions => Wf.ImageRegions();

        ProcessMemory ProcessMemory => Wf.ProcessMemory();

        public ProcessTargets ContextPaths {get; private set;}

        protected override void OnInit()
        {
            ContextPaths = new ProcessTargets(AppDb.DbCapture().Root);
        }

        public void EmitContext(Timestamp ts)
            => EmitContext(ApiPacks.create(ts));

        public void CollectMemStats(Timestamp ts)
        {
            var pipe = Wf.Runtime();
            var pre = ApiPacks.create(ts,"prejit");
            EmitContext(pre);
            var members = Wf.ApiJit().JitCatalog();
            var post = ApiPacks.create(ts,"prejit");
            EmitContext(post);
        }

        public void EmitContext(IApiPack dst)
        {
            var flow = Running("Emiting process context");
            var process = Process.GetCurrentProcess();
            var parts = ProcessMemory.EmitPartitions(process, dst.PartitionPath(process));
            var regions = Regions.EmitRegions(process, dst.RegionPath(process));
            ProcessMemory.EmitHashes(process, parts, dst);
            ProcessMemory.EmitHashes(process, regions, dst);
            EmitDump(process, dst.DumpPath(process));
            Ran(flow,"Emitted process context");
        }

        public void EmitDump(Process process, FS.FilePath dst)
        {
            var dumping = EmittingFile(dst);
            DumpEmitter.emit(process, dst.Format(PathSeparator.BS), DumpTypeOption.Full);
            EmittedFile(dumping,1);
        }
   }
}