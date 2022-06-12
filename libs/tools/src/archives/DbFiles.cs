//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DbFiles
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public DbFiles(FS.FolderPath root)
        {
            Root = root;
        }


        public ITargetArchive ProjectData(ProjectId id)
            => new DbTargets(new DbTargets(Root,"projects"), id);

        public ITargetArchive Targets()
            => new DbTargets(Root);

        public ITargetArchive Targets(string scope)
            => new DbTargets(Root, scope);

        public ISourceArchive Sources()
            => new DbSources(Root);

        public ISourceArchive Sources(string scope)
            => new DbSources(Root, scope);

        public FS.Files Files()
            => Root.Files(true);

        public FS.Files Files(bool recursive)
            => Root.Files(recursive);

        public FS.Files Files(FileKind kind, bool recursive = true)
            => Root.Files(kind.Ext(), recursive);

        public ListedFiles List()
            => new ListedFiles(Root.EnumerateFiles(true).Array().Mapi((i,x) => new ListedFile(i,x)));

        public Deferred<FS.FilePath> Enumerate()
            => Root.EnumerateFiles(true);

        public FS.FileName File(string name, FileKind kind)
            => FS.file(name, kind.Ext());

        public FS.FileName File(string @class, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", @class, name), kind.Ext());

        public FS.FilePath Path(string name, FileKind kind)
            => Root + File(name, kind);

        public FS.FilePath Path(string @class, string name, FileKind kind)
            => sources(Root, @class).Root + File(@class, name,kind);

        public FS.FilePath Path(FS.FileName file)
            => Root + file;

        public FS.FilePath Table<T>()
            where T : struct
                => Root + Tables.filename<T>();

        public FS.FilePath Table<T>(ProjectId id)
            where T : struct
                => ProjectData(id).Table<T>(id);

        public FS.FilePath Table<T>(string prefix)
            where T : struct
                => Root + Tables.filename<T>(prefix);

        static ISourceArchive sources(FS.FolderPath root)
            => new DbSources(root);

        static ISourceArchive sources(FS.FolderPath root, string scope)
            => new DbSources(root, scope);

        public string Format()
            => Root.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator DbFiles(FS.FolderPath src)
            => new DbFiles(src);

        [MethodImpl(Inline)]
        public static implicit operator FS.FolderPath(DbFiles src)
            => src.Root;
    }
}