//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsCatalog
    {
        public static WsCatalog load(IWsProject src)
        {
            var dst = new WsCatalog();
            var files = src.ProjectFiles().Storage.Sort().Index();
            var count = files.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var fref = new FileRef(i, hash(file.ToUri().Format()), FileTypes.kind(file), file);
                dst.IdMap.Include(dst.PathMap.Include(fref, _ => fref.DocId), fref);
                dst.PathRefs.Include(file, fref);
            }

            return dst;
        }

        readonly PllMap<uint,FileRef> IdMap;

        readonly PllMap<FileRef,uint> PathMap;

        readonly PllMap<FS.FilePath,FileRef> PathRefs;

        WsCatalog()
        {
            IdMap = new();
            PathMap = new();
            PathRefs = new();
        }

        public Index<FileRef> Entries(string match)
            => PathRefs.Values.Array().Where(x => x.Path.Contains(match));

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