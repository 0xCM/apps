//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static core;
    using static Delegates;

    public class ApiCaptureRunner : WfSvc<ApiCaptureRunner>
    {
        ApiImmEmitter ImmEmitter => Service(Wf.ImmEmitter);

        ApiCatalogs ApiCatalogs => Service(Wf.ApiCatalogs);

        // [Op]
        // public ReadOnlySpan<AsmHostRoutines> Capture(ReadOnlySpan<IApiHost> hosts, FS.FolderPath dst)
        // {
        //     var hostcount = hosts.Length;
        //     var buffer = list<AsmHostRoutines>();
        //     for(var i=0; i<hostcount; i++)
        //         buffer.Add(ApiCapture.CaptureHost(skip(hosts,i), dst));
        //     return buffer.ViewDeposited();
        // }

        public void EmitImm(Index<PartId> parts, IApiPack dst)
        {
            var flow = Running("EmitImm");
            ImmEmitter.Emit(parts, dst);
            Wf.Ran(flow);
        }

        public void EmitImm(ReadOnlySpan<ApiHostUri> hosts, IApiPack dst, SpanReceiver<AsmRoutine> receiver = null)
        {
            var flow = Running("EmitImm");
            ImmEmitter.Emit(hosts, dst, receiver);
            Ran(flow);
        }

        // public Index<AsmHostRoutines> Capture(Index<PartId> parts)
        //     => Capture(ApiRuntimeCatalog.PartIdentities, DefaultOptions);

        // static ApiMembers members(Index<AsmHostRoutines> src)
        //     => ApiMembers.create(src.SelectMany(x => x.Members));

        // public Index<AsmHostRoutines> Capture(Index<PartId> parts, CaptureWorkflowOptions options)
        // {
        //     var flow = Running();
        //     var ts = core.timestamp();
        //     var dst = ApiCode.ApiPack(ts);
        //     Status(Seq.enclose(parts.Storage));
        //     var captured = CaptureParts(parts, dst);

        //     if((options & CaptureWorkflowOptions.EmitImm) != 0)
        //         EmitImm(parts, dst);

        //     if((options & CaptureWorkflowOptions.CaptureContext) != 0)
        //     {
        //         Pipe.EmitContext(ts);
        //         Rebase(members(captured), dst);
        //     }

        //     Ran(flow);
        //     return captured;
        // }

        // public Index<AsmHostRoutines> Capture(ReadOnlySpan<ApiHostUri> hosts, CaptureWorkflowOptions options)
        // {
        //     var flow = Running();
        //     var ts = core.timestamp();
        //     var dst = ApiCode.ApiPack(ts);
        //     Status(Seq.enclose(hosts).Format());
        //     var captured = CaptureHosts(hosts,dst);
        //     if((options & CaptureWorkflowOptions.EmitImm) != 0)
        //         EmitImm(hosts, dst);

        //     if((options & CaptureWorkflowOptions.CaptureContext) != 0)
        //     {
        //         Pipe.EmitContext(ts);
        //         Rebase(AsmHostRoutines.members(captured), dst);
        //     }

        //     Ran(flow);
        //     return captured;
        // }

        // public Index<AsmHostRoutines> Capture(PartId part, CaptureWorkflowOptions? options = null)
        //     => Capture(array(part), CaptureWorkflowOptions.EmitImm);

        public void Rebase(ApiMembers members, IApiPack dst)
        {
            var flow = Running("Rebasing members");
            var entries = ApiCatalogs.Rebase(members, dst.Table<ApiCatalogEntry>());
            Ran(flow);
        }

        // Index<AsmHostRoutines> CaptureParts(Index<PartId> parts, IApiPack dst)
        // {
        //     var flow = Running();
        //     var captured = ApiCapture.CaptureParts(parts, dst);
        //     Ran(flow);
        //     return captured;
        // }

        // Index<AsmHostRoutines> CaptureHosts(ReadOnlySpan<ApiHostUri> src, IApiPack dst)
        // {
        //     var flow = Running();
        //     var captured = ApiCapture.CaptureHosts(src, dst);
        //     Ran(flow);
        //     return captured;
        // }

        void EmitImm(ReadOnlySpan<ApiHostUri> hosts, IApiPack dst)
        {
            var flow = Running();
            ImmEmitter.Emit(hosts,dst);
            Ran(flow);
        }

        const CaptureWorkflowOptions DefaultOptions = CaptureWorkflowOptions.CaptureContext | CaptureWorkflowOptions.EmitImm;
    }
}