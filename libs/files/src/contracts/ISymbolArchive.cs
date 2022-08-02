//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    public interface ISymbolArchive : IRootedArchive
    {
        IDbSources DotNet()
            => Sources(dotnet);

        IDbSources DotNet(string name)
            => DotNet().Sources(name);

        FS.FolderPath DotNet(byte major, byte minor, byte revision)
            => DotNet(FS.FolderName.version(major, minor, revision).Format()).Root;
    }
}