//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public class DumpArchives : AppService<DumpArchives>
    {
        FS.FolderPath Dir => FS.dir("j:/dumps");

        public DumpPaths DumpPaths()
            => new DumpPaths(Dir, Env.Db + FS.folder(tables) + FS.folder("dumps.tables"));

        public DumpArchive Default()
            => new DumpArchive(Dir);

        public DumpArchive Refs()
            => new (Env.CacheRoot + FS.folder(dumps) + FS.folder(images));

        public DumpArchive DotNet()
            => new (Refs().DumpRoot() + FS.folder(EnvFolders.dotnet));
    }
}