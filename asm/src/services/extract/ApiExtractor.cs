//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;

    using Z0.Asm;

    using static core;

    [ApiHost]
    public partial class ApiExtractor : AppService<ApiExtractor>
    {
        ApiExtractParser Parser;

        ApiResolver Resolver;

        AsmDecoder Decoder;

        ApiHexPacks HexPacks;

        ApiExtractChannel Channel;

        ConcurrentBag<ApiHostDataset> DatasetReceiver;

        Index<ApiHostDataset> CollectedDatasets;

        ApiPackArchive PackArchive;

        byte[] Buffer;

        Index<ResolvedPart> ResolvedParts;

        Index<AsmRoutine> SortedRoutines;

        AsmFormatConfig FormatConfig;

        ApiCatalogs ApiCatalogs;

        public ApiExtractor()
        {
            Buffer = ApiExtracts.buffer();
            SortedRoutines = array<AsmRoutine>();
            ResolvedParts = array<ResolvedPart>();
            FormatConfig = AsmFormatConfig.@default(out var _);
        }

        protected override void OnInit()
        {
            Parser = ApiExtracts.parser();
            Resolver = Wf.ApiResolver();
            Decoder = Wf.AsmDecoder();
            HexPacks = Wf.ApiHexPacks();
            Channel = new ApiExtractChannel();
            DatasetReceiver = new();
            ApiCatalogs = Wf.ApiCatalogs();
        }

        void ClearTargets(IApiPack pack)
        {
            PackArchive.HexPackRoot().Clear();
            PackArchive.AsmCaptureRoot().Clear(true);
        }

        void ResolveParts(ReadOnlySpan<IPart> parts)
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
        {
            var parts = Wf.ApiCatalog.Parts.ToReadOnlySpan();
            ResolveParts(parts);
        }

        void ExtractParts(IApiPack pack)
        {
            ExtractParts(ResolvedParts, false);
        }

        void EmitProcessContext(IApiPack pack)
        {
            var flow = Wf.Running("Emitting process context");
            var ts = pack.Timestamp;
            if(!ts.IsNonZero)
                ts = now();

            var dir = pack.Archive().ContextRoot();
            var process = Process.GetCurrentProcess();
            var pipe = Wf.ProcessContextPipe();
            var procparts = pipe.EmitPartitions(process, ts, dir);
            var regions = pipe.EmitRegions(process, ts, dir);
            pipe.EmitDump(process, pack.ProcDumpPath(process, ts));
            Wf.Ran(flow);
        }

        void EmitContext(IApiPack pack)
        {
            if(pack.ExtractSettings.EmitContext)
                EmitProcessContext(pack);
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

        ReadOnlySpan<ApiCatalogEntry> EmitApiCatalog(Timestamp ts)
            => ApiCatalogs.EmitApiCatalog(ApiMembers.create(CollectedDatasets.SelectMany(x => x.Members)), PackArchive.ApiCatalogPath());

        internal ApiCollection Run(ApiExtractChannel receivers, IApiPack pack)
        {
            Channel = receivers;
            PackArchive = ApiPackArchive.create(pack.Root);
            RedirectEmissions("capture", pack.Root);
            ClearTargets(pack);
            ResolveParts(pack);
            ExtractParts(pack);
            CollectRoutines(pack);
            EmitApiCatalog(pack.Timestamp);
            EmitContext(pack);
            EmitAnalyses(pack);
            var collection = new ApiCollection();
            collection._ResolvedParts = ResolvedParts;
            return collection;
        }

        FS.FolderPath SegDir
            => Db.TableDir("segments");
    }
}