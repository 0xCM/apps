//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public readonly struct SymbolPaths : IFileArchive
    {
        public static SymbolPaths create(EnvData env)
            => new SymbolPaths(env.CacheRoot + FS.folder(symbols));

        public static SymbolPaths create(FS.FolderPath root)
            => new SymbolPaths(root);

        public FS.FolderPath Root {get;}

        internal SymbolPaths(FS.FolderPath root)
        {
            Root = root;
        }

        public FS.FolderPath SymbolCacheRoot()
            => Root;

        public FS.FolderPath DefaultSymbolCache()
            => SymbolCacheRoot() + FS.folder(@default);

        public FS.FolderPath DotNetSymbolRoot()
            => SymbolCacheRoot() + FS.folder(dotnet);

        public Index<FS.FolderPath> DotNetSymbolDirs()
            => DotNetSymbolRoot().SubDirs();

        public FS.Files DotNetSymbolFiles(FS.FolderName folder)
            => DotNetSymbolDir(folder).Files(false);

        public FS.FolderPath DotNetSymbolDir(FS.FolderName folder)
            => DotNetSymbolRoot() + folder;

        public FS.FolderPath DotNetSymbolDir(byte major, byte minor, byte revision)
            => DotNetSymbolRoot() + FS.FolderName.version(major, minor, revision);
    }
}