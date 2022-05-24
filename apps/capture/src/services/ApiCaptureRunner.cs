//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics;

    using Z0.Asm;

    using static core;

    public class ApiCaptureRunner : AppService<ApiCaptureRunner>
    {
        ApiCaptureService ApiCapture => Service(Wf.ApiCapture);

        ApiImmEmitter ImmEmitter => Service(Wf.ImmEmitter);

        [Op]
        public ReadOnlySpan<AsmHostRoutines> Capture(ReadOnlySpan<IApiHost> hosts, FS.FolderPath dst)
        {
            var capture = Wf.ApiCapture();
            var hostcount = hosts.Length;
            var routines = list<AsmHostRoutines>();
            for(var i=0; i<hostcount; i++)
                routines.Add(capture.CaptureHost(skip(hosts,i), dst));
            return routines.ViewDeposited();
        }

        public void EmitImm(Index<PartId> parts, FS.FolderPath root)
        {
            var flow = Wf.Running(nameof(EmitImm));
            Wf.ImmEmitter().Emit(parts, root);
            Wf.Ran(flow);
        }

        public void EmitImm(ReadOnlySpan<ApiHostUri> hosts, FS.FolderPath root, Delegates.SpanReceiver<AsmRoutine> receiver = null)
        {
            var flow = Running(nameof(EmitImm));
            Wf.ImmEmitter().Emit(hosts, root, receiver);
            Ran(flow);
        }

        public Index<AsmHostRoutines> Capture(Index<PartId> parts)
            => Capture(Wf.ApiCatalog.PartIdentities, DefaultOptions);

        static ApiMembers members(Index<AsmHostRoutines> src)
            => ApiMembers.create(src.SelectMany(x => x.Members));

        public Index<AsmHostRoutines> Capture(Index<PartId> parts, CaptureWorkflowOptions options)
        {
            var flow = Running();
            Status(Seq.enclose(parts.Storage));
            var captured = CaptureParts(parts);

            if((options & CaptureWorkflowOptions.EmitImm) != 0)
                EmitImm(parts);

            if((options & CaptureWorkflowOptions.CaptureContext) != 0)
            {
                var ts = EmitContext();
                EmitRebase(members(captured), ts);
            }

            Ran(flow);
            return captured;
        }

        public Index<AsmHostRoutines> Capture(ReadOnlySpan<ApiHostUri> hosts, CaptureWorkflowOptions options)
        {
            using var flow = Wf.Running(nameof(Capture));
            Status(Seq.enclose(hosts).Format());
            var captured = CaptureHosts(hosts);

            if((options & CaptureWorkflowOptions.EmitImm) != 0)
                EmitImm(hosts);

            if((options & CaptureWorkflowOptions.CaptureContext) != 0)
            {
                var ts = EmitContext();
                EmitRebase(AsmHostRoutines.members(captured), ts);
            }

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

        Index<AsmHostRoutines> CaptureHosts(ReadOnlySpan<ApiHostUri> src)
        {
            var flow = Running();
            var captured = ApiCapture.CaptureHosts(src);
            Ran(flow);
            return captured;
        }

        void EmitImm(Index<PartId> parts)
        {
            var flow = Running();
            ImmEmitter.Emit(parts);
            Ran(flow);
        }

        void EmitImm(ReadOnlySpan<ApiHostUri> hosts)
        {
            var flow = Running();
            ImmEmitter.Emit(hosts);
            Ran(flow);
        }

        void EmitRebase(ApiMembers members, Timestamp ts)
        {
            var rebasing = Running(nameof(EmitRebase));
            var dst = Db.ContextTable<ApiCatalogEntry>(ts);
            var entries = Wf.ApiCatalogs().EmitApiCatalog(members, dst);
            Ran(rebasing);
        }

        Timestamp EmitContext()
        {
            var ts = core.timestamp();
            var dir = Db.CaptureContextRoot();
            var process = Process.GetCurrentProcess();
            var pipe = Wf.ProcessContextPipe();
            var summaries = pipe.EmitPartitions(process, ts);
            var details = pipe.EmitRegions(process, ts);
            var archive = DumpArchive.create();
            pipe.EmitDump(process, archive.DumpPath(process, ts));
            return ts;
        }

        const CaptureWorkflowOptions DefaultOptions = CaptureWorkflowOptions.CaptureContext | CaptureWorkflowOptions.EmitImm;
    }
}