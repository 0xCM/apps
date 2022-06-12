//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DbTargets : ITargetArchive<DbTargets>
    {
        readonly FS.FolderPath Root;

        public DbTargets(FS.FolderPath root, string scope)
        {
            Root = root + FS.folder(scope);
        }

        public DbTargets(FS.FolderPath root)
        {
            Root = root;
        }

        FS.FolderPath IRootedArchive.Root
            => Root;

        FS.FolderPath Scoped()
            => Root;

        public DbTargets Delete()
        {
            Root.Delete();
            return this;
        }

        public DbTargets Clear()
        {
            Root.Clear();
            return this;
        }

        public FS.Files Files()
            => Root.AllFiles;

        public FS.Files Files(FS.FileExt ext)
            => Root.Files(ext, true);

        public FS.Files Files(FileKind kind)
            => Root.Files(kind.Ext(), true);

        public DbSources Sources()
            => new DbSources(Root);

        public DbSources Sources(string scope)
            => Sources().Sources(scope);

        public DbTargets Targets()
            => new DbTargets(Root);

        public DbTargets Targets(string scope)
            => new DbTargets(Scoped(), scope);

        public FS.FolderPath Dir(string scope)
            => Root + FS.folder(scope);

        public FS.FileName File(string name, FileKind kind)
            => FS.file(name, kind.Ext());

        public FS.FileName File(string scope, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}.{2}", Root.FolderName, scope, name), kind.Ext());

        public FS.FilePath Path(string name, FileKind kind)
            => Scoped() + File(name, kind);

        public FS.FilePath MsilPath(ApiHostUri host)
            => Root + FS.hostfile(host, FS.Il);

        public FS.FilePath Path(FS.FileName file)
            => Root + file;

        public FS.FilePath Path(string scope, string name, FileKind kind)
            => Targets(scope).Path(File(scope, name,kind));

        public FS.FilePath Table<T>()
            where T : struct
                => Root + Tables.filename<T>();

        public FS.FilePath Table<T>(string prefix)
            where T : struct
                => Root + Tables.filename<T>(prefix);

        public static implicit operator FS.FolderPath(DbTargets src)
            => src.Scoped();

        public string Format()
            => Root.Format();

        public override string ToString()
            => Format();

        public static DbTargets Empty => new DbTargets(FS.FolderPath.Empty);
    }
}