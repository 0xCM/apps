//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public class ApiEvalControl
    {
        public static ApiEvalControl create(IWfRuntime wf, IBoundSource source, FS.FolderPath root, uint bufferSize)
            => new ApiEvalControl(wf, source, root, bufferSize);

        readonly IWfRuntime Wf;

        readonly byte BufferCount;

        readonly uint BufferSize;

        readonly IApiEvalDispatcher Dispatcher;

        readonly IApiCatalog ApiGlobal;

        internal ApiEvalControl(IWfRuntime wf, IBoundSource source, FS.FolderPath root, uint buffersize)
        {
            Wf = wf;
            BufferCount = 3;
            BufferSize = buffersize;
            Dispatcher = Wf.EvalDispatcher(source, BufferSize);
            ApiGlobal = wf.ApiCatalog;
        }

        void ExecuteHost(BufferTokens buffers, ApiHostUri uri)
        {
            var src = Wf.Db().ParsedExtractPath(uri);
            if(!src.Exists)
                return;

            var flow = Wf.Running($"Running {uri.Format()} evaluaton workflow");
            if(!Wf.ApiCatalog.FindHost(uri, out var host))
                return;


            var catalog = Wf.ApiRuntime().HostCatalog(host);
            if(catalog.IsEmpty)
                return;

            var hex = Wf.ApiHex();
            var members = Wf.ApiIndexBuilder().CreateMemberIndex(catalog);
            Wf.Status($"Indexed {members.EntryCount} {uri} members");

            var blocks = hex.ReadBlocks(src);
            Wf.Status($"Read {blocks.Count} {uri} operations from {src}");

            var operations = ApiIndex.create(blocks);
            Wf.Status($"Hydrated {operations.EntryCount} {uri} operations from {blocks.Count} blocks");

            var identities =  members.Keys.ToHashSet();
            identities.IntersectWith(operations.Keys);

            Wf.Status($"Found {identities.Count} common operation identifiers");


            Wf.Ran(flow);
        }

        void ExecuteCatalog(IApiPartCatalog catalog)
        {
            var flow = Wf.Running($"Evaluating {catalog.PartId.Format()}");
            using var buffers = memory.native(BufferSize, BufferCount);
            foreach(var host in catalog.OperationHosts)
                ExecuteHost(buffers.Tokenize(), host.HostUri);
            Wf.Ran(flow);
        }

        bool Enabled => false;

        public void Evaluate(ReadOnlySpan<PartId> parts)
        {
            if(Enabled)
            {
                var catalogs = ApiGlobal.PartCatalogs(parts.ToArray()).View;
                var count = catalogs.Length;
                var flow = Wf.Running($"Evaluating {count} parts");
                using var buffers = memory.native(BufferSize, BufferCount);
                for(var i=0; i<count; i++)
                    ExecuteCatalog(skip(catalogs,i));

                iter(ApiGlobal.PartCatalogs(parts.ToArray()), ExecuteCatalog);
            }
        }
    }
}