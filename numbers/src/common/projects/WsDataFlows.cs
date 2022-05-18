//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsDataFlows
    {
        public static WsDataFlows create(FileCatalog files, ReadOnlySpan<ToolCmdFlow> src)
            => new WsDataFlows(files, src);

        ConstLookup<FS.FileUri,List<FS.FileUri>> Lookup;

        ConstLookup<FS.FileUri,FS.FileUri> Ancestors;

        Index<WsDataFlow> Data;

        public FileCatalog FileCatalog {get;}

        public Index<FileRef> Files(FileKind k0)
            => FileCatalog.Entries(k0);

        public Index<FileRef> Files(FileKind k0, FileKind k1)
            => FileCatalog.Entries(k0, k1);

        public Index<FileRef> Files(FileKind k0, FileKind k1, FileKind k2)
            => FileCatalog.Entries(k0, k1, k2);

        public Index<FileRef> Sources(FileKind kind)
            => FileCatalog.Entries(kind).Where(e => Lookup.ContainsKey(e.Path));

        public Index<FileRef> Sources()
            => map(Lookup.Keys, x => FileCatalog.Entry(x.Path));

        public bool Root(FS.FilePath dst, out FileRef source)
        {
            var buffer = list<FileRef>();
            var target = FileCatalog[dst];
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
            var buffer = list<FileRef>();
            var target = FileCatalog[dst];
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
                src = FileCatalog.Entry(uri.Path);
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

        WsDataFlows(FileCatalog files, ReadOnlySpan<ToolCmdFlow> src)
        {
            FileCatalog = files;
            var count = src.Length;
            var flows = alloc<WsDataFlow>(count);
            var lookup = dict<FS.FileUri,List<FS.FileUri>>();
            var lineage = dict<FS.FileUri,FS.FileUri>();

            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(flows,i);
                dst = WsDataFlow.from(skip(src,i));
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
    }
}