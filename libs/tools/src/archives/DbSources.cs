//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DbSources : ISourceArchive<DbSources>
    {
        public readonly DbFiles DbFiles {get;}

        [MethodImpl(Inline)]
        public DbSources(FS.FolderPath root, string scope)
        {
            DbFiles = root + FS.folder(scope);
        }

        [MethodImpl(Inline)]
        public DbSources(FS.FolderPath root)
        {
            DbFiles = root;
        }

        [MethodImpl(Inline)]
        public DbSources(IRootedArchive root, string scope)
        {
            DbFiles = new DbFiles(root.Root + FS.folder(scope));
        }

        [MethodImpl(Inline)]
        public DbSources(IRootedArchive root)
        {
            DbFiles = new DbFiles(root.Root);
        }

        public FS.FolderPath Root
            => DbFiles;

        // public DbSources Sources(string scope)
        //     => DbFiles.Sources(scope);

        // public FS.Files Files()
        //     => DbFiles.Files(true);

        // public FS.Files Files(FileKind kind)
        //     => DbFiles.Files(kind, true);

        // public FS.FileName File(string name, FileKind kind)
        //     => DbFiles.File(name, kind);

        // public FS.FileName File(string @class, string name, FileKind kind)
        //     => DbFiles.File(@class, name, kind);

        // public FS.FilePath Path(string name, FileKind kind)
        //     => DbFiles.Path(name,kind);

        // public FS.FilePath Path(FS.FileName file)
        //     => DbFiles.Path(file);

        // public FS.FilePath Path(string @class, string name, FileKind kind)
        //     => DbFiles.Path(@class, name, kind);

        // public FS.FilePath Table<T>()
        //     where T : struct
        //         => DbFiles.Table<T>();

        public string Format()
            => DbFiles.Format();

        public override string ToString()
            => Format();

        public static implicit operator FS.FolderPath(DbSources src)
            => src.DbFiles;

        public static DbSources Empty => new DbSources(FS.FolderPath.Empty);
    }
}