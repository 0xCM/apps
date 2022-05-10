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

        [MethodImpl(Inline)]
        public DbTargets(FS.FolderPath root, string scope)
        {
            Root = root;
            Scope = scope;
        }

        public FS.FolderPath Targets()
            => Root + FS.folder(Scope);

        public FS.FolderPath Targets(string scope)
            => Targets() + FS.folder(scope);

        public FS.FileName File(string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", Scope, name), kind.Ext());

        public FS.FileName File(string scope, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}.{2}", Scope, scope, name), kind.Ext());

        public FS.FilePath Path(string name, FileKind kind)
            => Targets() + File(name,kind);

        public FS.FilePath Path(string scope, string name, FileKind kind)
            => Targets(scope) + File(scope, name,kind);

        public FS.FilePath Table<T>()
            where T : struct
                => Targets() + Tables.filename<T>();
    }
}