//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ToolFlowIndex
    {
        public static ToolFlowIndex create(FileCatalog files, ReadOnlySpan<ToolCmdFlow> src)
            => new ToolFlowIndex(files, src);

        ConstLookup<FS.FileUri,List<FS.FileUri>> Lookup;

        Index<ToolDataFlow> Data;

        public FileCatalog FileCatalog {get;}

        public Index<FileRef> Files(FileKind kind)
            => FileCatalog.Entries(kind);

        public Index<FileRef> Sources(FileKind kind)
            => FileCatalog.Entries(kind).Where(e => Lookup.ContainsKey(e.Path));

        public Index<FileRef> Sources()
            => map(Lookup.Keys, x => FileCatalog.Entry(x.Path));

        public Index<FileRef> Targets(FS.FilePath src)
        {
            if(Lookup.Find(src, out var targets))
                return map(targets, x => FileCatalog.Entry(x.Path));
            else
                return sys.empty<FileRef>();
        }

        public void DescribeFlows(FileKind srckind, ITextBuffer dst)
        {
            var sources = Sources(srckind);
            foreach(var source in sources)
            {
                var path = source.Path;
                dst.AppendLine(path.ToUri());
                var targets = Targets(path);
                foreach(var target in targets)
                {
                    DescribeTargets(0u, target, dst);
                }
            }
        }

        void DescribeTargets(uint indent, in FileRef file, ITextBuffer dst)
        {
            var path = file.Path;
            dst.IndentLineFormat(indent, " -> {0}", path.ToUri());
            var targets = Targets(path);
            indent += 4;
            foreach(var target in targets)
            {
                DescribeTargets(indent, target, dst);
            }
        }

        ToolFlowIndex(FileCatalog files, ReadOnlySpan<ToolCmdFlow> src)
        {
            FileCatalog = files;
            var count = src.Length;
            var flows = alloc<ToolDataFlow>(count);
            var lookup = dict<FS.FileUri,List<FS.FileUri>>();
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(flows,i);
                dst = flow(skip(src,i));
                if(lookup.TryGetValue(dst.Source, out var targets))
                {
                    targets.Add(dst.Target);
                }
                else
                {
                    lookup[dst.Source] = new();
                    lookup[dst.Source].Add(dst.Target);
                }
            }

            Lookup = lookup;
            Data = flows;
        }

        [MethodImpl(Inline)]
        static ToolDataFlow flow(in ToolCmdFlow src)
        {
            var flow = DataFlows.flow(src.TargetName, src.SourcePath.ToUri(), src.TargetPath.ToUri());
            return new ToolDataFlow(DataFlows.identify(flow), flow);
        }

        public ReadOnlySpan<ToolDataFlow> Flows
        {
            [MethodImpl(Inline)]
            get => Data;
        }
    }
}