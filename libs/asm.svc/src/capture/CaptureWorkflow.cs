//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class CaptureWorkflow : IRunnable<CaptureWorkflow.CaptureSettings>
    {
        public static ReadOnlySeq<ApiCatalogEntry> catalog(ApiMembers members)
        {
            var buffer = sys.alloc<ApiCatalogEntry>(members.Count);
            var @base = members.BaseAddress;
            var rebase = members[0].BaseAddress;
            for(var i=0u; i<members.Count; i++)
            {
                ref readonly var member = ref members[i];
                ref var record = ref seek(buffer,i);
                record.Sequence = i;
                record.ProcessBase = @base;
                record.MemberBase = member.BaseAddress;
                record.MemberOffset = member.BaseAddress - @base;
                record.MemberRebase = (uint)(member.BaseAddress - rebase);
                record.HostName = member.Host.HostName;
                record.PartName = member.Host.Part.Format();
                record.OpUri = member.OpUri;
            }

            return buffer;
        }

        readonly IWfEventTarget Log;

        readonly IApiPack Target;

        readonly IWfRuntime Wf;

        readonly IWfSvc Svc;

        public readonly CaptureSettings Settings;
        public CaptureWorkflow(IWfSvc svc, CaptureSettings settings)
        {
            Svc = svc;
            Log = svc.Wf.EventLog;
            Target = ApiPacks.create();
            Wf = svc.Wf;
            Settings = settings;
        }

        CaptureSettings IRunnable<CaptureSettings>.Settings
            => Settings;

        ApiMd ApiMd => Wf.ApiMd();

        CliEmitter CliEmitter => Wf.CliEmitter();

        Runtime Runtime => Wf.Runtime();

        ApiPacks ApiPacks => Wf.ApiPacks();

        public void Run()
        {
            var parts = ApiPartCapture.create(Wf);
            using var dispenser = Dispense.composite();
            var hosts = parts.Capture(Target, dispenser);
            var members = ApiQuery.members(hosts.SelectMany(x => x.Resolved.Members).Where(x => x != null).Array());
            var rebased = catalog(members);
            Svc.TableEmit(rebased, Target.Table<ApiCatalogEntry>(), UTF8);
            ApiMd.EmitDatasets(Target);
            CliEmitter.Emit(CliEmitOptions.@default(), Target);
            Runtime.EmitContext(Target);
            ApiPacks.Link(Target);
        }
    }
}