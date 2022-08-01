//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Runtime : WfSvc<Runtime>
    {
        public ApiMembers JitCatalog()
            => ClrJit.jit(Wf.ApiParts.Catalog, EventLog);

        public void CollectMemStats()
        {
            var pre = ApiPacks.create(core.timestamp());
            EmitContext(pre);
            var members = JitCatalog();
            var post = ApiPacks.create(core.timestamp());
            EmitContext(post);
        }

        public void EmitContext(IApiPack dst)
        {
            var flow = Running("Emiting process context");
            var process = Process.GetCurrentProcess();
            EmitProcessModules(process, dst);
            EmitDump(process, dst);
            Ran(flow,"Emitted process context");
        }

        public void EmitProcessModules(Process src, IApiPack dst)
            => TableEmit(ImageMemory.modules(src), dst.ProcessModules());

        public void EmitDump(Process process, IApiPack pack)
        {
            var dst = pack.DumpPath(process);
            var dumping = EmittingFile(dst);
            DumpEmitter.emit(process, dst.Format(PathSeparator.BS), DumpTypeOption.Everything);
            EmittedBytes(dumping, dst.Size);
        }
   }
}