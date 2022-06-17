//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static core;

    [ApiHost]
    public class ApiExtractor : AppService<ApiExtractor>
    {
        ApiResolver Resolver;

        AsmDecoder Decoder;

        ApiExtractChannel Channel;

        ConcurrentBag<ApiHostDataset> DatasetReceiver;

        Index<ApiHostDataset> CollectedDatasets;

        IApiPackArchive PackArchive;

        Index<ResolvedPart> ResolvedParts;

        Index<AsmRoutine> SortedRoutines;

        AsmFormatConfig FormatConfig;

        ApiCatalogs ApiCatalogs;

        ApiCodeExtractor CodeExtractor => Wf.CodeExtractor();

        public ApiExtractor()
        {
            SortedRoutines = array<AsmRoutine>();
            ResolvedParts = array<ResolvedPart>();
            FormatConfig = AsmFormatConfig.@default(out var _);
        }

        protected override void OnInit()
        {
            Resolver = Wf.ApiResolver();
            Decoder = Wf.AsmDecoder();
            Channel = new ApiExtractChannel();
            DatasetReceiver = new();
            ApiCatalogs = Wf.ApiCatalogs();
        }

        internal ResolvedParts Run(ApiExtractChannel receivers, IApiPack dst)
        {
            Channel = receivers;
            PackArchive = ApiPackArchive.create(dst.Root);
            Wf.RedirectEmissions(core.controller(), dst.Root, core.timestamp(), "capture");
            ResolveParts(dst);
            ExtractParts(dst);
            CollectRoutines(dst);
            EmitApiCatalog(dst);
            EmitContext(dst);
            EmitAnalyses(dst);
            return new ResolvedParts(ResolvedParts);
        }

        void ResolveParts(IApiPack pack)
            => ResolveParts(Wf.ApiCatalog.Parts.ToReadOnlySpan(), pack);

        void ResolveParts(ReadOnlySpan<IPart> parts, IApiPack pack)
        {
            var count = parts.Length;
            ResolvedParts = alloc<ResolvedPart>(count);
            ref var dst = ref ResolvedParts.First;
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(parts,i);
                var resolution = Resolver.ResolvePart(part);
                seek(dst,i) = resolution;
                Channel.Raise(new PartResolvedEvent(resolution));
            }
        }

        void CollectRoutines(IApiPack pack)
        {
            CollectedDatasets = DatasetReceiver.Array();
            SortedRoutines = CollectedDatasets.SelectMany(x => x.Routines.Where(r => r != null && r.IsNonEmpty));
            SortedRoutines.Sort();
        }

        ReadOnlySpan<ApiCatalogEntry> EmitApiCatalog(IApiPack dst)
            => ApiCatalogs.EmitApiCatalog(ApiMembers.create(CollectedDatasets.SelectMany(x => x.Members)), PackArchive.ApiCatalogPath());

        void ExtractParts(IApiPack pack)
            => ExtractParts(ResolvedParts, pack);

        public uint ExtractParts(ReadOnlySpan<ResolvedPart> src, IApiPack dst)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
                counter += ExtractPart(skip(src,i), dst);
            return counter;
        }

        public uint ExtractPart(in ResolvedPart src, IApiPack dst)
        {
            var count = (uint)src.Hosts.Count;
            if(count == 0)
                return 0;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                var extracted = ExtractHost(src.Hosts[i], dst);
                counter += extracted.Routines.Count;
                DatasetReceiver.Add(extracted);
            }
            return counter;
        }

        ApiHostDataset ExtractHost(in ResolvedHost src, IApiPack dst)
        {
            var code = CodeExtractor.ExtractHostCode(src, dst, PackArchive);
            return CreateDataset(code, EmitRoutines(code));
        }

        ApiHostDataset CreateDataset(ApiHostCode code, Index<AsmRoutine> asm)
        {
            var dst = new ApiHostDataset();
            dst.HostResolution = code.Resolved;
            dst.HostExtracts = code.Raw;
            dst.HostBlocks = code.Parsed;
            dst.Routines = asm;
            return dst;
        }

        Index<AsmRoutine> EmitRoutines(ApiHostCode code)
        {
            var decoded = DecodeMembers(code);
            EmitAsmSource(code.Resolved.Host, decoded);
            return decoded;
        }

        Index<AsmRoutine> DecodeMembers(ApiHostCode code)
        {
            var data = code.Parsed.View;
            var count = data.Length;
            var buffer = alloc<AsmRoutine>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var member = ref skip(data,i);
                var outcome = Decoder.DecodeRoutine(member, out var decoded);
                if(outcome)
                {
                    seek(dst,i) = decoded;
                    Channel.Raise(new MemberDecodedEvent(member, decoded));
                }
                else
                {
                    Error(outcome.Message);
                }
            }
            return buffer;
        }

        void EmitAsmSource(ApiHostUri host, ReadOnlySpan<AsmRoutine> src)
        {
            var counter = 0u;
            var count = (uint)src.Length;
            if(count == 0)
                return;
            var dst = PackArchive.HostAsm(host);
            var flow = EmittingFile(dst);
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
            {
                ref readonly var routine = ref skip(src,i);
                if(routine is null || routine.IsEmpty)
                    continue;

                writer.Write(AsmFormatter.format(routine, FormatConfig));
                counter++;
            }
            EmittedFile(flow, counter);
        }

        void EmitContext(IApiPack pack)
        {
            if(pack.ExtractSettings.EmitContext)
                Wf.Runtime().EmitProcessContext(pack);
        }

        void EmitAnalyses(IApiPack pack)
        {
            if(pack.ExtractSettings.Analyze)
                Wf.AsmAnalyzer().Analyze(SortedRoutines, PackArchive);
        }
    }
}