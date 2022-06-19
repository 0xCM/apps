//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static core;

    public class ApiCaptureRunner : AppService<ApiCaptureRunner>
    {
        ApiCaptureService ApiCapture => Service(Wf.ApiCaptureLegacy);

        ApiImmEmitter ImmEmitter => Service(Wf.ImmEmitter);

        Runtime Pipe => Service(Wf.Runtime);

        ApiCatalogs ApiCatalogs => Service(Wf.ApiCatalogs);

        ApiCodeFiles ApiCode => Wf.ApiCodeFiles();

        [Op]
        public ReadOnlySpan<AsmHostRoutines> Capture(ReadOnlySpan<IApiHost> hosts, FS.FolderPath dst)
        {
            var hostcount = hosts.Length;
            var buffer = list<AsmHostRoutines>();
            for(var i=0; i<hostcount; i++)
                buffer.Add(ApiCapture.CaptureHost(skip(hosts,i), dst));
            return buffer.ViewDeposited();
        }

        public void EmitImm(Index<PartId> parts, IApiPack dst)
        {
            var flow = Running("EmitImm");
            ImmEmitter.Emit(parts, dst);
            Wf.Ran(flow);
        }

        public void EmitImm(ReadOnlySpan<ApiHostUri> hosts, IApiPack dst, Delegates.SpanReceiver<AsmRoutine> receiver = null)
        {
            var flow = Running("EmitImm");
            ImmEmitter.Emit(hosts, dst, receiver);
            Ran(flow);
        }

        public Index<AsmHostRoutines> Capture(Index<PartId> parts)
            => Capture(ApiRuntimeCatalog.PartIdentities, DefaultOptions);

        static ApiMembers members(Index<AsmHostRoutines> src)
            => ApiMembers.create(src.SelectMany(x => x.Members));

        public Index<AsmHostRoutines> Capture(Index<PartId> parts, CaptureWorkflowOptions options)
        {
            var flow = Running();
            var ts = core.timestamp();
            var dst = ApiCode.ApiPack(ts);
            Status(Seq.enclose(parts.Storage));
            var captured = CaptureParts(parts);

            if((options & CaptureWorkflowOptions.EmitImm) != 0)
                EmitImm(parts, dst);

            if((options & CaptureWorkflowOptions.CaptureContext) != 0)
            {
                Pipe.EmitContext(ts);
                EmitRebase(members(captured), ts);
            }

            Ran(flow);
            return captured;
        }

        public Index<AsmHostRoutines> Capture(ReadOnlySpan<ApiHostUri> hosts, CaptureWorkflowOptions options)
        {
            var flow = Running(nameof(Capture));
            var ts = core.timestamp();
            var dst = ApiCode.ApiPack(ts);
            Status(Seq.enclose(hosts).Format());
            var captured = CaptureHosts(hosts,dst);
            if((options & CaptureWorkflowOptions.EmitImm) != 0)
                EmitImm(hosts, dst);

            if((options & CaptureWorkflowOptions.CaptureContext) != 0)
            {
                Pipe.EmitContext(ts);
                EmitRebase(AsmHostRoutines.members(captured), ts);
            }

            Ran(flow);
            return captured;
        }

        public Index<AsmHostRoutines> Capture(PartId part, CaptureWorkflowOptions? options = null)
            => Capture(array(part), CaptureWorkflowOptions.EmitImm);

        Index<AsmHostRoutines> CaptureParts(Index<PartId> parts)
        {
            var flow = Running();
            var captured = ApiCapture.CaptureParts(parts);
            Ran(flow);
            return captured;
        }

        Index<AsmHostRoutines> CaptureHosts(ReadOnlySpan<ApiHostUri> src, IApiPack dst)
        {
            var flow = Running();
            var captured = ApiCapture.CaptureHosts(src);
            Ran(flow);
            return captured;
        }

        void EmitImm(ReadOnlySpan<ApiHostUri> hosts, IApiPack dst)
        {
            var flow = Running();
            ImmEmitter.Emit(hosts,dst);
            Ran(flow);
        }

        void EmitRebase(ApiMembers members, Timestamp ts)
        {
            var rebasing = Running(nameof(EmitRebase));
            var dst = Db.ContextTable<ApiCatalogEntry>(ts);
            var entries = ApiCatalogs.EmitApiCatalog(members, dst);
            Ran(rebasing);
        }

        const CaptureWorkflowOptions DefaultOptions = CaptureWorkflowOptions.CaptureContext | CaptureWorkflowOptions.EmitImm;
    }
}