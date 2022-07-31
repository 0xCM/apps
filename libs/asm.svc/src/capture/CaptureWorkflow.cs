//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class CaptureWorkflow : IRunnable<CaptureWorkflow.CaptureSettings>
    {
        readonly IWfRuntime Wf;

        readonly IWfSvc Svc;

        readonly IApiPack Target;

        readonly IWfEventTarget EventTarget;

        public readonly CaptureSettings Settings;

        readonly WfEmit Emitter;

        public CaptureWorkflow(IWfSvc svc, CaptureSettings settings)
        {
            Svc = svc;
            Wf = svc.Wf;
            Settings = settings;
            Target = ApiPacks.create();
            EventTarget =  svc.Wf.EventLog;
            Emitter = svc.Emitter;
        }

        CaptureSettings IRunnable<CaptureSettings>.Settings
            => Settings;

        ApiMd ApiMd => Wf.ApiMd();

        IApiCatalog Catalog => ApiMd.Catalog;

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCodeSvc ApiCode => Wf.ApiCode();

        AppDb AppDb => AppDb.Service;

        CliEmitter CliEmitter => Wf.CliEmitter();

        Runtime Runtime => Wf.Runtime();

        ApiPacks ApiPacks => Wf.ApiPacks();

        public void Run()
        {            
            using var dispenser = Dispense.composite();
            var hosts = Run(dispenser);
        }

        public HostCollection Run(ICompositeDispenser dispenser)
        {
            var hosts = Capture(dispenser);
            var members = ClrJit.members(hosts.SelectMany(x => x.Resolved.Members).Where(x => x != null).Array());
            var rebased = catalog(members);
            Emitter.TableEmit(rebased, Target.Table<ApiCatalogEntry>(), UTF8);
            ApiMd.EmitDatasets(Target);
            CliEmitter.Emit(CliEmitOptions.@default(), Target);
            Runtime.EmitContext(Target);
            ApiPacks.Link(Target);
            CheckReloaded(EventTarget);
            return hosts;
        }

        void RedirectEmissions()
            => Wf.RedirectEmissions(Loggers.emission(ExecutingPart.Component, Target.Path("capture.emissions", FileKind.Csv)));

        public HostCollection Capture(ICompositeDispenser dispenser)
        {
            RedirectEmissions();
            return Capture(Catalog, dispenser);
        }

        public HostCollection Capture(IApiCatalog src, ICompositeDispenser dispenser)
        {
            var dst = bag<CollectedHost>();
            iter(src.PartCatalogs(), part => Capture(part, dispenser, dst, EventTarget), Settings.PllExec);
            return new HostCollection(dispenser,dst.ToIndex());
        }

        void Capture(IApiPartCatalog part, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst, IWfEventTarget log)
        {
            var tmp = bag<CollectedHost>();
            Z0.ApiCode.gather(part, dispenser, tmp, log);
            var code = tmp.ToArray();
            ApiCode.Emit(part.PartId, code, Target);
            EmitAsm(dispenser, code);
            iter(tmp, x => dst.Add(x));
        }

        public HostCollection Capture()
        {
            RedirectEmissions();
            using var dispenser = Dispense.composite();
            return Capture(Catalog, dispenser);
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

        void CheckHeaps1(IApiPack src)
        {
            var files = ApiPartFiles.create(src, PartId.Assets);
        }

        void CheckAssets2()
        {
            var src = TextAssets.strings(typeof(AsciText));
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var res = ref src[i];
             
            }
        }

        void CheckLookups(IWfEventTarget dst)
        {
            var log = text.emitter();
            var capacity = Pow2.T16;
            var blocks = Z0.ApiCode.blocks(Target).View;
            var count = blocks.Length;
            var result = Outcome.Success;
            if(count > capacity)
            {
                result = (false, "Insufficient cpacity");
                log.AppendLine(result.Message);
                Errors.Throw(result);
            }

            var distinct = blocks.Map(b => b.BaseAddress).ToHashSet();
            if(distinct.Count != count)
            {
                result = (false, string.Format("There should be {0} distinct base addresses and yet there are {1}", count, distinct.Count));
                log.AppendLine(result.Message);
                Errors.Throw(result);
            }

            var symbols = MemoryStores.create(capacity);
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                symbols.Deposit(block.BaseAddress, block.Size, block.OpUri.Format());
            }

            log.AppendLine("Creating lookup");

            var lookup = symbols.ToLookup();
            var entries = slice(lookup.Symbols, 0,symbols.EntryCount);
            Emitter.TableEmit(entries, AppDb.ApiTargets().PrefixedTable<MemorySymbol>("api.addresses"));
            var found = 0;
            var hashes = entries.Map(x => x.HashCode).ToHashSet();
            if(hashes.Count != count)
                log.AppendLineFormat("There should be {0} distinct hash codes and yet there are {1}", count, hashes.Count);

            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                if(lookup.FindIndex(block.BaseAddress, out var index))
                    found++;
            }

            log.AppendLineFormat("Blocks: {0}", count);
            log.AppendLineFormat("Found: {0}", found);
            dst.Deposit(Events.row(log.Emit()));
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

        public static FS.FilePath csv(FS.FolderPath src, ApiHostUri host)
            => src + host.FileName(FS.PCsv);

        void CheckSize(ApiMemberCode src)
        {
            var count = src.MemberCount;
            var rebase = MemoryAddress.Zero;
            var size = 0u;
            for(var i=0; i<count; i++)
            {
                var seg = src.Segment(i);
                rebase = rebase + seg.Size;
                size += seg.Size;
            }

            Require.equal((ByteSize)size, src.CodeSize);
        }

        void PackHex(FS.FolderPath src, ApiHostUri host)
        {
            var counter = 0u;
            var memory = ApiHex.memory(csv(src, host));
            var blocks = memory.Sort().View;
            var buffer = span<char>(Pow2.T16);
            var dir = AppDb.ApiTargets("capture.test").Targets(string.Format("{0}.{1}", host.Part.Format(), host.HostName)).Root;
            var count = blocks.Length;
            for(var i=0; i<count; i++)
            {
                var dst = dir + FS.file(string.Format("{0:D5}", i), FS.XArray);
                var length = Hex.hexarray(skip(blocks,i).View, buffer);
                var content = text.format(slice(buffer,0,length));
                using var writer = dst.AsciWriter();
                writer.WriteLine(content);
            }
        }

        void CheckPackedHex(FS.FolderPath src)
        {
            var ext = FS.ext(FS.ext("parsed"), FS.XPack);
            var files = src.Files(ext).ToReadOnlySpan();
            var count = files.Length;
            var hex = list<ApiHostHex>();
            for(var i=0; i<count; i++)
            {
                var file = skip(files,i);
                var elements = file.FileName.Format().Split(Chars.Dot).ToReadOnlySpan();
                if(elements.Length < 2)
                    continue;

                var part = skip(elements,0);
                var id = ApiParsers.part(part);
                if(id == 0)
                    continue;

                var uri = ApiHostUri.define(id, skip(elements,1));
                hex.Add(new (uri, ApiHex.memory(file)));
            }
        }
    }
}