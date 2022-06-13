//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsCatalog
    {
        public static WsCatalog load(IProjectWs src)
        {
            var dst = new WsCatalog();
            dst.Include(Require.notnull(src));
            return dst;
        }

        public static WsCatalog load(ProjectId project)
            => load(DevWs.create(Env.load().DevWs).Project(project));

        readonly PllMap<uint,FileRef> IdMap;

        readonly PllMap<FileRef,uint> PathMap;

        readonly PllMap<FS.FilePath,FileRef> PathRefs;

        public void Include(IProjectWs project)
        {
            var src = project.ProjectFiles().Storage.Sort();
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var hash = alg.hash.marvin(path.ToUri().Format());
                var file = new FileRef(i, hash, FileKinder.kind(path), path);
                IdMap.Include(PathMap.Include(file, _ => file.DocId), file);
                PathRefs.Include(path, file);
            }
        }

        WsCatalog()
        {
            IdMap = new();
            PathMap = new();
            PathRefs = new();
        }

        public Index<FileRef> Entries(FileKind k0)
            => Entries().Where(e => e.Kind == k0);

        public Index<FileRef> Entries(FileKind k0, FileKind k1)
            => Entries().Where(e => e.Kind == k0 || e.Kind == k1);

        public Index<FileRef> Entries(FileKind k0, FileKind k1, FileKind k2)
            => Entries().Where(e => e.Kind == k0 || e.Kind == k1 || e.Kind == k2);

        public Index<FileRef> Entries()
            => map(IdMap.Keys, Entry).Sort();

        public FileRef Entry(FS.FilePath path)
        {
            PathRefs.Find(path, out var fref);
            return fref;
        }

        public FileRef Entry(uint docid)
        {
            IdMap.Find(docid, out var fref);
            return fref;
        }

        public FileRef this[FS.FilePath path]
        {
            [MethodImpl(Inline)]
            get => Entry(path);
        }

        public FileRef this[uint docid]
        {
            [MethodImpl(Inline)]
            get => Entry(docid);
        }
    }
}