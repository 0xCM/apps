//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public sealed class CaptureWfRunner
    {
        readonly IWfRuntime Wf;

        readonly IApiPack Target;

        readonly IWfEventTarget EventTarget;

        public readonly CaptureWfSettings Settings;

        readonly WfEmit Emitter;

        readonly CaptureTransport Transport;

        public CaptureWfRunner(IWfSvc svc, CaptureWfSettings settings, IApiPack dst, CaptureTransport transport)
        {
            Wf = svc.Wf;
            Target = dst;
            Settings = settings;
            EventTarget =  svc.Wf.EventLog;
            Emitter = svc.Emitter;
            Transport = transport;
            Wf.RedirectEmissions(Loggers.emission(Target.Path("capture.emissions", FileKind.Csv)));
        }

        ICompositeDispenser Dispenser
            => Transport.Dispenser;

        ApiMd ApiMd => Wf.ApiMd();

        IApiCatalog Catalog => ApiMd.Catalog;

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCodeSvc ApiCodeSvc => Wf.ApiCode();

        CliEmitter CliEmitter => Wf.CliEmitter();

        ApiPacks ApiPacks => Wf.ApiPacks();

        ImageRegions Regions => Wf.ImageRegions();

        ExecToken EmitMemberIndex(ReadOnlySeq<ApiEncoded> src, IApiPack dst)
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

            return Emitter.TableEmit(Transport.Transmit(buffer).View, dst.Table<EncodedMember>());
        }

        public ReadOnlySeq<ApiEncoded> Run()
        {
            var dispenser = Transport.Dispenser;
            var parts = Settings.Parts.IsEmpty ? Catalog.PartIdentities.ToSeq() : Settings.Parts;
            var running = Emitter.Running("Running capture workflow");
            var dst = bag<CollectedHost>();
            Capture(parts.View, dst);
            var collected = Transport.Transmit(dst.ToSeq());
            var blocks = collected.SelectMany(x => x.Blocks).Sort();
            EmitMemberIndex(blocks, Target);

            if(Settings.EmitCatalog)
            {
                var members = Transport.TransmitResolved(ApiQuery.members(collected.SelectMany(x => x.Resolved.Members)));
                var rebased = Transport.TransmitRebased(ApiCode.catalog(members));
                var path = Target.Table<ApiCatalogEntry>();
                Emitter.TableEmit(rebased, path, UTF8);
                Transport.TransmitReloaded(ApiCode.catalog(path, EventTarget));
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
                RuntimeEmitter.emit(Target,Emitter);
            }

            if(Settings.RunChecks)
            {
                
            }

            ApiPacks.Link(Target);
            Emitter.Ran(running, $"Captured {blocks.Count} blocks from {parts.Count} parts");
            return blocks;
        }

        ExecToken Capture(ReadOnlySpan<PartId> src, ConcurrentBag<CollectedHost> dst)
        {
            const string On = "concurrent execution enabled";
            const string Off = "concurrent execution disabled";
            var pll = Settings.PllExec;
            var pllmsg = pll ? On : Off;
            var parts = Catalog.PartIdentities.ToHashSet().Intersect(src).ToSeq();
            var running = Emitter.Running($"Capturing {parts.Count} parts with concurrent execution {pllmsg}:{parts.Delimit()}");
            iter(parts, id => Capture(id, dst), pll);
            return Emitter.Ran(running);
        }

        void Capture(PartId part, ConcurrentBag<CollectedHost> dst)
        {        
            var result = Catalog.PartCatalog(part, out var catalog);
            if(result)
            {
                Capture(catalog, Dispenser, dst, EventTarget);
            }
            else
                Emitter.Warn($"Part identifier {part} not found");
        }

        // public HostCollection Capture(IApiCatalog src)
        // {
        //     var dst = bag<CollectedHost>();
        //     Capture(src.PartCatalogs(), Dispenser);
        //     return new HostCollection(dst.ToIndex());
        // }

        // public HostCollection Capture(ReadOnlySpan<IApiPartCatalog> src, ICompositeDispenser dispenser)
        // {
        //     var buffer = bag<CollectedHost>();
        //     iter(src, part => Capture(part, dispenser, buffer, EventTarget), Settings.PllExec);
        //     return new HostCollection(buffer.Array());
        // }

        void Capture(IApiPartCatalog src, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst, IWfEventTarget log)
        {
            var tmp = bag<CollectedHost>();
            ApiCode.gather(src, dispenser, tmp, log, Settings.PllExec);
            var code = tmp.ToArray();
            ApiCodeSvc.Emit(src.PartId, code, Target, Settings.PllExec);
            EmitAsm(dispenser, code);
            iter(tmp, x => dst.Add(x));
            Transport.Transmit(src.Component);
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

   }
}