//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public class SymbolArchive : AppService<SymbolArchive>
    {
        public IDbSources Sources()
            => new DbSources(Env.CacheRoot, symbols);

        public IDbSources Sources(string scope)
            => new DbSources(Sources(), scope);

        public IDbSources DotNet()
            => Sources(dotnet);

        public IDbSources DotNet(string name)
            => DotNet().Sources(name);

        public FS.FolderPath DotNet(byte major, byte minor, byte revision)
            => DotNet(FS.FolderName.version(major, minor, revision).Format()).Root;
    }
}