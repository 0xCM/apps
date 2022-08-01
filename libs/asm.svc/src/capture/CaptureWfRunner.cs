//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public sealed class CaptureWfRunner : IRunnable<CaptureWfSettings>
    {
        readonly IWfRuntime Wf;

        readonly IWfSvc Svc;

        readonly IApiPack Target;

        readonly IWfEventTarget EventTarget;

        public readonly CaptureWfSettings Settings;

        readonly WfEmit Emitter;

        public CaptureWfRunner(IWfSvc svc, CaptureWfSettings settings)
        {
            Svc = svc;
            Wf = svc.Wf;
            Settings = settings;
            Target = ApiPacks.create();
            EventTarget =  svc.Wf.EventLog;
            Emitter = svc.Emitter;
            Wf.RedirectEmissions(Loggers.emission(Target.Path("capture.emissions", FileKind.Csv)));
        }

        CaptureWfSettings IRunnable<CaptureWfSettings>.Config
            => Settings;

        ApiMd ApiMd => Wf.ApiMd();

        IApiCatalog Catalog => ApiMd.Catalog;

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCodeSvc ApiCodeSvc => Wf.ApiCode();

        AppDb AppDb => AppDb.Service;

        CliEmitter CliEmitter => Wf.CliEmitter();

        Runtime Runtime => Wf.Runtime();

        ApiPacks ApiPacks => Wf.ApiPacks();

        ImageRegions Regions => Wf.ImageRegions();

        public void Run()
        {            
            using var dispenser = Dispense.composite();
            var hosts = Run(dispenser);
        }

        public HostCollection Run(ICompositeDispenser dispenser)
        {
            var parts = Settings.Parts;
            var hosts = parts.IsNonEmpty ? Capture(parts.View, dispenser) : Capture(dispenser);
            if(parts.IsNonEmpty)
                hosts = Capture(parts.View, dispenser);
            else
                hosts = Capture(dispenser);

            if(Settings.EmitCatalog)
            {
                var members = ClrJit.members(hosts.SelectMany(x => x.Resolved.Members).Where(x => x != null).Array());
                var rebased = ApiCode.catalog(members);
                Emitter.TableEmit(rebased, Target.Table<ApiCatalogEntry>(), UTF8);
            }

            if(Settings.EmitMetadata)
            {
                ApiMd.EmitDatasets(Target);
                CliEmitter.Emit(CliEmitOptions.@default(), Target);
            }

            if(Settings.EmitRegions)
            {
                Regions.EmitRegions(Process.GetCurrentProcess(), Target);
            }

            if(Settings.EmitContext)
            {
                Runtime.EmitContext(Target);                
            }

            if(Settings.RunChecks)
            {
                CheckReloaded(EventTarget);
            }

            ApiPacks.Link(Target);

            return hosts;
        }


        public HostCollection Capture(ICompositeDispenser dispenser)
        {
            return Capture(Catalog, dispenser);
        }

        public HostCollection Capture(IApiCatalog src, ICompositeDispenser dispenser)
        {
            var dst = bag<CollectedHost>();
            Capture(src.PartCatalogs(), dispenser);
            return new HostCollection(dst.ToIndex());
        }

        public HostCollection Capture(ReadOnlySpan<IApiPartCatalog> parts, ICompositeDispenser dispenser)
        {
            var buffer = bag<CollectedHost>();
            iter(parts, part => Capture(part, dispenser, buffer, EventTarget), Settings.PllExec);
            return new HostCollection(buffer.Array());
        }

        void Capture(IApiPartCatalog part, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst, IWfEventTarget log)
        {
            var tmp = bag<CollectedHost>();
            Z0.ApiCode.gather(part, dispenser, tmp, log);
            var code = tmp.ToArray();
            ApiCodeSvc.Emit(part.PartId, code, Target);
            EmitAsm(dispenser, code);
            iter(tmp, x => dst.Add(x));
        }

        public HostCollection Capture(ReadOnlySpan<PartId> parts, ICompositeDispenser dispenser)
        {
            var dst = HostCollection.Empty;
            var selected = Catalog.PartIdentities.ToHashSet().Intersect(parts);
            iter(selected, part => Capture(part, dispenser), Settings.PllExec);
            return dst;
        }

        public HostCollection Capture(PartId part, ICompositeDispenser dispenser)
        {
            var result = Catalog.PartCatalog(part, out var catalog);
            var dst = HostCollection.Empty;
            if(result)
            {
                var buffer = bag<CollectedHost>();
                Capture(catalog, dispenser, buffer, EventTarget);
                dst = buffer.Array();
            }
            else
            {
                Emitter.Warn($"Part identifier {part} not found");
            }
            return dst;
        }

        void EmitAsm(ICompositeDispenser symbols, ReadOnlySeq<CollectedHost> src)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var host = ref src[i];
                var path = Target.AsmExtractPath(host.Host);
                var flow = Emitter.EmittingFile(path);
                var size = ByteSize.Zero;
                using var writer = path.AsciWriter();
                for(var j=0; j<host.Blocks.Count; j++)
                {
                    ref readonly var blocks = ref host.Blocks[j];
                    var routine = AsmDecoder.Decode(blocks);
                    var asm = routine.AsmRender(routine);
                    size += (ulong)asm.Length;
                    writer.AppendLine(asm);
                }
                Emitter.EmittedFile(flow, AppMsg.EmittedBytes.Capture(size,path));
            }
        }


        void CheckReloaded(IWfEventTarget log)
        {
            using var members = Z0.ApiCode.load(Target, PartId.AsmCore, log);
            for(var i=0; i<members.MemberCount; i++)
            {
                ref readonly var member = ref members.Member(i);
                ref readonly var token = ref members.Token(i);
                var encoding = members.Encoding(i);
                ref readonly var entry = ref member.EntryAddress;
                ref readonly var entryRb = ref member.EntryRebase;
                ref readonly var target = ref member.TargetAddress;
                ref readonly var targetRb = ref member.TargetRebase;
                ref readonly var uri = ref member.Uri;
            }
        }
   }
}