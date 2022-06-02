//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public class SymbolArchive : AppService<SymbolArchive>
    {
        public FS.FolderPath Root
            => Env.CacheRoot + FS.folder(symbols);

        public DbTargets Targets()
            => new DbTargets(Root);

        public DbTargets Targets(string scope)
            => new DbTargets(Targets(), scope);
    }
}