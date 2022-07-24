//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    public class WsDataFlows
    {
        ConstLookup<FS.FileUri,List<FS.FileUri>> Lookup;

        ConstLookup<FS.FileUri,FS.FileUri> Ancestors;

        Index<FileFlow> Data;

        public readonly WsCatalog Catalog;

        public WsDataFlows(WsCatalog files, ReadOnlySpan<CmdFlow> src)
        {
            Catalog = files;
            var count = src.Length;
            var flows = sys.alloc<FileFlow>(count);
            var lookup = dict<FS.FileUri,List<FS.FileUri>>();
            var lineage = dict<FS.FileUri,FS.FileUri>();

            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(flows,i);
                dst = flow(skip(src,i));
                if(lookup.TryGetValue(dst.Source, out var targets))
                {
                    targets.Add(dst.Target);
                    lineage[dst.Target] = dst.Source;

                }
                else
                {
                    lookup[dst.Source] = new();
                    lookup[dst.Source].Add(dst.Target);
                    lineage[dst.Target] = dst.Source;
                }
            }

            Lookup = lookup;
            Data = flows;
            Ancestors = lineage;
        }

        public ref readonly Index<FileFlow> Completed
        {
            [MethodImpl(Inline)]
            get => ref Data;
        }

        public Index<FileRef> Files(FileKind k0)
            => Catalog.Entries(k0);

        public Index<FileRef> Files(FileKind k0, FileKind k1)
            => Catalog.Entries(k0, k1);

        public Index<FileRef> Files(FileKind k0, FileKind k1, FileKind k2)
            => Catalog.Entries(k0, k1, k2);

        public Index<FileRef> Sources(FileKind kind)
            => Catalog.Entries(kind).Where(e => Lookup.ContainsKey(e.Path));

        public Index<FileRef> Sources()
            => map(Lookup.Keys, x => Catalog.Entry(x.Path));

        public bool Root(FS.FilePath dst, out FileRef source)
        {
            var buffer = core.list<FileRef>();
            var target = Catalog[dst];
            Lineage(target, buffer);
            buffer.Reverse();
            if(buffer.Count != 0)
            {
                source = buffer[0];
                return true;
            }
            else
            {
                source = FileRef.Empty;
                return false;
            }
        }

        public Index<FileRef> Lineage(FS.FilePath dst)
        {
            var buffer = core.list<FileRef>();
            var target = Catalog[dst];
            buffer.Add(target);
            Lineage(target, buffer);
            buffer.Reverse();
            return buffer.ToArray();
        }

        public void Lineage(in FileRef target, List<FileRef> dst)
        {
            if(Source(target.Path, out var source))
            {
                dst.Add(source);
                Lineage(source, dst);
            }
        }

        public bool Source(FS.FileUri dst, out FileRef src)
        {
            if(Ancestors.Find(dst, out var uri))
            {
                src = Catalog.Entry(uri.Path);
                return true;
            }
            else
            {
                src = FileRef.Empty;
                return false;
            }
        }

        public Index<FileRef> Targets(FS.FilePath src)
        {
            if(Lookup.Find(src, out var targets))
                return core.map(targets, x => Catalog.Entry(x.Path));
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
                    DescribeTargets(0u, target, dst);
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

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));
    }
}