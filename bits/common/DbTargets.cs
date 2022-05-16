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

        public DbTargets Delete()
        {
            Targets().Delete();
            return this;
        }

        public DbTargets Clear()
        {
            Targets().Clear();
            return this;
        }

        [MethodImpl(Inline)]
        public DbTargets Scoped(string scope)
            => new DbTargets(Targets(), scope);

        public FS.FolderPath Targets()
            => Root + FS.folder(Scope);

        public FS.FolderPath Targets(string scope)
            => Targets() + FS.folder(scope);

        public FS.FileName File(string name, FileKind kind)
            => FS.file(name, kind.Ext());

        public FS.FileName File(string scope, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}.{2}", Scope, scope, name), kind.Ext());

        public FS.FilePath Path(string name, FileKind kind)
            => Targets() + File(name,kind);

        public FS.FilePath Path(string scope, string name, FileKind kind)
            => Targets(scope) + File(scope, name,kind);

        public FS.FilePath Table<T>()
            where T : struct
                => Targets() + Tables.filename<T>();

        public FS.FilePath Table<T>(string prefix)
            where T : struct
                => Targets() + Tables.filename<T>(prefix);

        public static implicit operator FS.FolderPath(DbTargets src)
            => src.Targets();
    }
}