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

        void EmitImm(ReadOnlySpan<ApiHostUri> hosts, IApiPack dst)
        {
            var flow = Running();
            ImmEmitter.Emit(hosts,dst);
            Ran(flow);
        }

        const CaptureWorkflowOptions DefaultOptions = CaptureWorkflowOptions.CaptureContext | CaptureWorkflowOptions.EmitImm;
    }
}