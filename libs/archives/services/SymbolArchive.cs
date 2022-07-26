//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

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