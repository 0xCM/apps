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

        public DbTargets Delete()
        {
            OutDir().Delete();
            return this;
        }

        public DbTargets Clear()
        {
            OutDir().Clear();
            return this;
        }

        [MethodImpl(Inline)]
        public DbTargets Targets(string scope)
            => new DbTargets(OutDir(), scope);

        FS.FolderPath OutDir()
            => Root + FS.folder(Scope);

        public FS.FolderPath Dir(string scope)
            => Root + FS.folder(scope);

        public FS.FolderPath OutDir(string scope)
            => OutDir() + FS.folder(scope);

        public FS.FileName File(string name, FileKind kind)
            => FS.file(name, kind.Ext());

        public FS.FileName File(string scope, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}.{2}", Scope, scope, name), kind.Ext());

        public FS.FilePath Path(string name, FileKind kind)
            => OutDir() + File(name,kind);

        public FS.FilePath Path(FS.FileName file)
            => OutDir() + file;

        public FS.FilePath Path(string scope, string name, FileKind kind)
            => OutDir(scope) + File(scope, name,kind);

        public FS.FilePath Table<T>()
            where T : struct
                => OutDir() + Tables.filename<T>();

        public FS.FilePath Table<T>(string prefix)
            where T : struct
                => OutDir() + Tables.filename<T>(prefix);

        public static implicit operator FS.FolderPath(DbTargets src)
            => src.OutDir();
    }
}