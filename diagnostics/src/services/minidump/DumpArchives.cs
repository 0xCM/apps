//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public class DumpArchives : AppService<DumpArchives>
    {
        public DbTargets Targets()
            => new DbTargets(FS.dir("j:/"), dumps);

        public DbTargets Targets(string scope)
            => new DbTargets(Targets(), scope);

        public DumpArchive Archive()
            => new DumpArchive(Targets());

        public DumpArchive Archive(string scope)
            => new DumpArchive(Targets(scope));

        public DumpArchive Archive(string scope, Timestamp ts)
            => new DumpArchive(Targets(ts.Format()));

        public DumpPaths DumpPaths()
            => new DumpPaths(Targets(), Env.Db + FS.folder(tables) + FS.folder($"{dumps}.tables"));

        public DumpArchive Refs()
            => new (Env.CacheRoot + FS.folder(dumps) + FS.folder(images));

        public DumpArchive DotNet()
            => new (Refs().DumpRoot() + FS.folder(EnvFolders.dotnet));
    }
}