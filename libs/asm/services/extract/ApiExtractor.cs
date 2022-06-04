//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static core;

    [ApiHost]
    public partial class ApiExtractor : AppService<ApiExtractor>
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

        void ClearTargets(IApiPack pack)
        {
            // PackArchive.HexPackRoot().Clear();
            // PackArchive.AsmCaptureRoot().Clear(true);
        }

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

        void ResolveParts(IApiPack pack)
            => ResolveParts(Wf.ApiCatalog.Parts.ToReadOnlySpan(), pack);

        void ExtractParts(IApiPack pack)
            => ExtractParts(ResolvedParts, pack);

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

        void CollectRoutines(IApiPack pack)
        {
            CollectedDatasets = DatasetReceiver.Array();
            SortedRoutines = CollectedDatasets.SelectMany(x => x.Routines.Where(r => r != null && r.IsNonEmpty));
            SortedRoutines.Sort();
        }

        ReadOnlySpan<ApiCatalogEntry> EmitApiCatalog(IApiPack dst)
            => ApiCatalogs.EmitApiCatalog(ApiMembers.create(CollectedDatasets.SelectMany(x => x.Members)), PackArchive.ApiCatalogPath());

        internal ResolvedParts Run(ApiExtractChannel receivers, IApiPack dst)
        {
            Channel = receivers;
            PackArchive = ApiPackArchive.create(dst.Root);
            Wf.RedirectEmissions("capture", dst.Root);
            ClearTargets(dst);
            ResolveParts(dst);
            ExtractParts(dst);
            CollectRoutines(dst);
            EmitApiCatalog(dst);
            EmitContext(dst);
            EmitAnalyses(dst);
            return new ResolvedParts(ResolvedParts);
        }
    }
}