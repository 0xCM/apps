//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public class SymbolArchive : AppService<SymbolArchive>
    {
        public DbSources Sources()
            => new DbSources(Env.CacheRoot, symbols);

        public DbSources Sources(string scope)
            => new DbSources(Sources(), scope);
        
        public DbSources DotNet()
            => Sources(dotnet);

        public DbSources DotNet(string name)
            => DotNet().Scoped(name);

        public DbSources DotNet(byte major, byte minor, byte revision)
            => DotNet(FS.FolderName.version(major, minor, revision).Format());
    }
}