//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class FileCatalog
    {
        public static FileCatalog create()
            => new();

        public static FileCatalog load(IProjectWs project)
        {
            var dst = create();
            dst.Include(project);
            return dst;
        }

        int FileId;

        [MethodImpl(Inline)]
        uint NextId()
            => (uint)inc(ref FileId);

        readonly PllMap<uint,FileRef> IdMap;

        readonly PllMap<FileRef,uint> PathMap;

        readonly PllMap<FS.FilePath,FileRef> PathRefs;

        public void Include(IProjectWs project)
        {
            var src = project.Files().Exclude(FS.Cmd).Storage.Sort();
            var id = NextId();
            var count = src.Length;
            var dst = alloc<DocPath>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = (id++,skip(src,i));

            iter(dst, Include, true);
        }

        void Include(DocPath src)
        {
            var hash = alg.hash.marvin(src.Path.Format());
            var kind = Match(src.Path);
            var fref = new FileRef(src.DocId, kind, hash, src.Path);
            IdMap.Include(PathMap.Include(fref, _ => fref.DocId), fref);
            PathRefs.Include(src.Path, fref);
        }

        FileCatalog()
        {
            IdMap = new();
            PathMap = new();
            PathRefs = new();
        }

        public Index<FileRef> Entries(FileKind kind)
            => Entries().Where(e => e.Kind == kind);

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
            get => Entry(path);
        }

        public FileRef this[uint docid]
            => Entry(docid);

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

        static FileCatalog()
        {
            var symbols = Symbols.index<FileKind>();
            var kinds = symbols.Kinds;
            FileKindMatch = symbols.View.Map(s => ("." + s.Expr.Format().ToLower(), s.Kind)).ToSortedDictionary(TextLengthComparer.create(true));
        }

        static SortedDictionary<string,FileKind> FileKindMatch;
    }
}