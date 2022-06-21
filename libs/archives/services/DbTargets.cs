//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DbTargets : IDbTargets<DbTargets>
    {
        public readonly DbFiles DbFiles {get;}

        [MethodImpl(Inline)]
        public DbTargets(IRootedArchive src, string scope)
        {
            DbFiles = new DbFiles(src.Root + FS.folder(scope));
        }

        [MethodImpl(Inline)]
        public DbTargets(FS.FolderPath root, string scope)
        {
            DbFiles = root + FS.folder(scope);
        }

        [MethodImpl(Inline)]
        public DbTargets(FS.FolderPath root)
        {
            DbFiles = root;
        }

        [MethodImpl(Inline)]
        public DbTargets(IRootedArchive src)
        {
            DbFiles = new DbFiles(src.Root);
        }

        public FS.FolderPath Root
            => DbFiles;

        public string Format()
            => Root.Format();

        public override string ToString()
            => Format();

        public static DbTargets Empty => new DbTargets(FS.FolderPath.Empty);
    }
}