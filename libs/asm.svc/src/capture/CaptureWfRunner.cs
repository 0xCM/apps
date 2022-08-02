//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public interface ICaptureReceiver
    {
        void Capturing(Assembly src);

        void Captured(Assembly src);
    }

    public sealed class CaptureWfRunner : IRunnable<CaptureWfSettings>
    {
        readonly IWfRuntime Wf;

        readonly IApiPack Target;

        readonly IWfEventTarget EventTarget;

        public readonly CaptureWfSettings Settings;

        readonly WfEmit Emitter;

        readonly ICaptureReceiver Receiver;

        public CaptureWfRunner(IWfSvc svc, CaptureWfSettings settings, IApiPack dst, ICaptureReceiver receiver)
        {
            Wf = svc.Wf;
            Target = dst;
            Settings = settings;
            EventTarget =  svc.Wf.EventLog;
            Emitter = svc.Emitter;
            Receiver = receiver;
            Wf.RedirectEmissions(Loggers.emission(Target.Path("capture.emissions", FileKind.Csv)));
        }

        CaptureWfSettings IRunnable<CaptureWfSettings>.Settings
            => Settings;

        ApiMd ApiMd => Wf.ApiMd();

        IApiCatalog Catalog => ApiMd.Catalog;

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCodeSvc ApiCodeSvc => Wf.ApiCode();

        CliEmitter CliEmitter => Wf.CliEmitter();

        Runtime Runtime => Wf.Runtime();

        ApiPacks ApiPacks => Wf.ApiPacks();

        ImageRegions Regions => Wf.ImageRegions();

        public void Run()
        {            
            using var dispenser = Dispense.composite();
            var hosts = Run(dispenser);
        }

        ExecToken EmitCaptureIndex(ReadOnlySeq<ApiEncoded> src, IApiPack dst)
        {
            var count = src.Count;
            var buffer = sys.alloc<EncodedMember>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = ApiCode.member(src[i]);
            var rebase = min(buffer.Select(x => (ulong)x.EntryAddress).Min(), buffer.Select(x => (ulong)x.TargetAddress).Min());
            for(var i=0; i<count; i++)
            {
                seek(buffer,i).EntryRebase = skip(buffer,i).EntryAddress - rebase;
                seek(buffer,i).TargetRebase = skip(buffer,i).TargetAddress - rebase;
            }

            return Emitter.TableEmit(buffer, dst.Path("capture.index", FileKind.Csv));
        }

        public ReadOnlySeq<ApiEncoded> Run(ICompositeDispenser dispenser)
        {
            var parts = Settings.Parts.IsEmpty ? Catalog.PartIdentities.ToSeq() : Settings.Parts;
            var running = Emitter.Running($"Caturing {parts.Count} parts");
            var dst = bag<CollectedHost>();
            Capture(parts.View, dispenser, dst);
            var collected = dst.ToSeq();
            var blocks = collected.SelectMany(x => x.Blocks).Sort();
            EmitCaptureIndex(blocks, Target);

            if(Settings.EmitCatalog)
            {
                var members = ApiQuery.members(collected.SelectMany(x => x.Resolved.Members));
                var rebased = ApiCode.catalog(members);
                var path = Target.Table<ApiCatalogEntry>();
                Emitter.TableEmit(rebased, path, UTF8);
                var reloaded = ApiCode.catalog(path, EventTarget);
            }

            if(Settings.EmitMetadata)
            {
                ApiMd.EmitDatasets(Target);
                CliEmitter.Emit(Settings.CliEmissions, Target);
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
            Emitter.Ran(running, $"Captured {blocks.Count} blocks from {parts.Count} parts");
            return blocks;
        }

        public HostCollection Capture(ICompositeDispenser dispenser)
            => Capture(Catalog, dispenser);

        public HostCollection Capture(IApiCatalog src, ICompositeDispenser dispenser)
        {
            var dst = bag<CollectedHost>();
            Capture(src.PartCatalogs(), dispenser);
            return new HostCollection(dst.ToIndex());
        }

        public HostCollection Capture(ReadOnlySpan<IApiPartCatalog> src, ICompositeDispenser dispenser)
        {
            var buffer = bag<CollectedHost>();
            iter(src, part => Capture(part, dispenser, buffer, EventTarget), Settings.PllExec);
            return new HostCollection(buffer.Array());
        }

        void Capture(IApiPartCatalog src, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst, IWfEventTarget log)
        {
            Receiver.Capturing(src.Component);
            var tmp = bag<CollectedHost>();
            ApiCode.gather(src, dispenser, tmp, log, Settings.PllExec);
            var code = tmp.ToArray();
            ApiCodeSvc.Emit(src.PartId, code, Target, Settings.PllExec);
            EmitAsm(dispenser, code);
            iter(tmp, x => dst.Add(x));
            Receiver.Captured(src.Component);
        }

        public void Capture(ReadOnlySpan<PartId> parts, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst)
        {
            var selected = Catalog.PartIdentities.ToHashSet().Intersect(parts);
            iter(selected, part => Capture(part, dispenser, dst), Settings.PllExec);
        }

        public void Capture(PartId part, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst)
        {
            var result = Catalog.PartCatalog(part, out var catalog);
            if(result)
                Capture(catalog, dispenser, dst, EventTarget);
            else
                Emitter.Warn($"Part identifier {part} not found");
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