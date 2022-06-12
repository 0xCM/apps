//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public class SymbolArchive : AppService<SymbolArchive>
    {
        public ISourceArchive Sources()
            => new DbSources(Env.CacheRoot, symbols);

        public ISourceArchive Sources(string scope)
            => new DbSources(Sources(), scope);

        public ISourceArchive DotNet()
            => Sources(dotnet);

        public ISourceArchive DotNet(string name)
            => DotNet().Sources(name);

        public FS.FolderPath DotNet(byte major, byte minor, byte revision)
            => DotNet(FS.FolderName.version(major, minor, revision).Format()).Root;
    }
}