//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DbSources : ISourceArchive<DbSources>
    {
        readonly FS.FolderPath Root;

        [MethodImpl(Inline)]
        public DbSources(FS.FolderPath root, string scope)
        {
            Root = root + FS.folder(scope);
        }

        [MethodImpl(Inline)]
        public DbSources(FS.FolderPath root)
        {
            Root = root;
        }

        FS.FolderPath IRootedArchive.Root
            => Root;

        public DbSources Scoped(string scope)
            => new DbSources(Sources(), scope);

        public FS.FolderPath Dir()
            => Root;

        public FS.FolderPath Sources()
            => Root;

        /// <summary>
        /// Returns all files provided by the source
        /// </summary>
        public FS.Files Files()
            => Sources().Files(true);

        /// <summary>
        /// Returns all source-provided files of specified kind
        /// </summary>
        /// <param name="kind">The kind</param>
        public FS.Files Files(FileKind kind)
            => Sources().Files(kind.Ext(), true);

        public DbSources Sources(string scope)
            => new DbSources(Sources(),scope);

        public FS.FileName File(string name, FileKind kind)
            => FS.file(name, kind.Ext());

        public FS.FileName File(string @class, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", @class, name), kind.Ext());

        public FS.FilePath Path(string name, FileKind kind)
            => Sources() + File(name, kind);

        public FS.FilePath Path(FS.FileName file)
            => Sources() + file;

        public FS.FilePath Path(string @class, string name, FileKind kind)
            => Sources(@class).Path(File(@class, name,kind));

        public FS.FilePath Table<T>()
            where T : struct
                => Sources() + Tables.filename<T>();

        public string Format()
            => Dir().Format();

        public override string ToString()
            => Format();

        public static implicit operator FS.FolderPath(DbSources src)
            => src.Sources();

        public static DbSources Empty => new DbSources(FS.FolderPath.Empty);
    }
}