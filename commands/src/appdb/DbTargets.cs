//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DbTargets
    {
        readonly FS.FolderPath Root;

        readonly string Scope;

        public DbTargets(FS.FolderPath root, string scope)
        {
            if(text.empty(scope))
            {
                Scope = root.FolderName.Format();
                Root = FS.dir(root.Format(PathSeparator.FS).Replace($"/{Scope}", EmptyString));
            }
            else
            {
                Root = root;
                Scope = scope;
            }
        }

        public DbTargets(FS.FolderPath root)
        {
            Scope = root.FolderName.Format();
            Root = FS.dir(root.Format(PathSeparator.FS).Replace($"/{Scope}", EmptyString));
        }

        public FS.FolderPath Dir()
            => Scoped();

        FS.FolderPath Scoped()
            => Root + FS.folder(Scope);

        public DbTargets Delete()
        {
            Scoped().Delete();
            return this;
        }

        public DbTargets Clear()
        {
            Scoped().Clear();
            return this;
        }

        public FS.Files Files()
            => Scoped().AllFiles;

        public DbSources ToSource()
            => new DbSources(Root, Scope);

        public DbTargets Targets(string scope)
            => new DbTargets(Scoped(), scope);

        public FS.FolderPath Dir(string scope)
            => Root + FS.folder(scope);

        public FS.FolderPath OutDir(string scope)
            => Scoped() + FS.folder(scope);

        public FS.FileName File(string name, FileKind kind)
            => FS.file(name, kind.Ext());

        public FS.FileName File(string scope, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}.{2}", Scope, scope, name), kind.Ext());

        public FS.FilePath Path(string name, FileKind kind)
            => Scoped() + File(name, kind);

        public FS.FilePath MsilPath(ApiHostUri host)
            => Root + FS.hostfile(host, FS.Il);

        public FS.FilePath Path(FS.FileName file)
            => Scoped() + file;

        public FS.FilePath Path(string scope, string name, FileKind kind)
            => OutDir(scope) + File(scope, name,kind);

        public FS.FilePath Table<T>()
            where T : struct
                => Scoped() + Tables.filename<T>();

        public FS.FilePath Table<T>(string prefix)
            where T : struct
                => Scoped() + Tables.filename<T>(prefix);

        public static implicit operator FS.FolderPath(DbTargets src)
            => src.Scoped();

        public string Format()
            => Dir().Format();

        public override string ToString()
            => Format();
    }
}