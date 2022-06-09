//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FileArchive : IRootedArchive<FileArchive>
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public FileArchive(FS.FolderPath root)
            => Root = root;

        public DbTargets Targets()
            => new DbTargets(Root);

        public DbTargets Targets(string scope)
            => new DbTargets(Root, scope);

        public DbSources Sources()
            => new DbSources(Root);

        public DbSources Sources(string scope)
            => new DbSources(Root, scope);

        [MethodImpl(Inline)]
        public static implicit operator FileArchive(FS.FolderPath src)
            => new FileArchive(src);
    }
}