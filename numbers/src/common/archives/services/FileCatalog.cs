//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class FileCatalog
    {
        public static FileCatalog load(IProjectWs src)
        {
            var dst = new FileCatalog();
            dst.Include(Require.notnull(src));
            return dst;
        }

        [MethodImpl(Inline)]
        public static ReadOnlySpan<FileKind> KnownKinds()
            => _FileKinds;

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
                var file = new FileRef(i, hash, Match(path), path);
                IdMap.Include(PathMap.Include(file, _ => file.DocId), file);
                PathRefs.Include(path, file);
            }
        }

        FileCatalog()
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

        static FileKind Match(FS.FilePath src)
        {
            var name = src.FileName.Format().ToLower();
            var kind = FileKind.None;
            foreach(var expr in FileKindMatch)
            {
                if(name.EndsWith(expr.Key))
                {
                    kind = expr.Value;
                    break;
                }
            }
            return kind;
        }

        static Index<FileKind> _FileKinds;

        static FileCatalog()
        {
            var symbols = Symbols.index<FileKind>();
            _FileKinds = symbols.Kinds.ToArray();
            FileKindMatch = symbols.View.Map(s => ("." + s.Expr.Format().ToLower(), s.Kind)).ToSortedDictionary(TextLengthComparer.create(true));
        }

        static SortedDictionary<string,FileKind> FileKindMatch;
    }
}