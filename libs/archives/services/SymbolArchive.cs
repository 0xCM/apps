//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public interface ISymbolArchive : IRootedArchive
    {
        IDbSources DotNet()
            => Sources(dotnet);

        IDbSources DotNet(string name)
            => DotNet().Sources(name);

        FS.FolderPath DotNet(byte major, byte minor, byte revision)
            => DotNet(FS.FolderName.version(major, minor, revision).Format()).Root;
    }

    public readonly struct SymbolArchive : ISymbolArchive
    {
        public static ISymbolArchive Service => new SymbolArchive();

        public FS.FolderPath Root {get;}

        public SymbolArchive()
        {
            Root = AppDb.Service.Archives().Sources(symbols).Root;
        }
    }
}