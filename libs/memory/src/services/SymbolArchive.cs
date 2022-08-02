//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SymbolArchive : ISymbolArchive
    {
        public static ISymbolArchive Service(FS.FolderPath root) => new SymbolArchive(root);

        public FS.FolderPath Root {get;}

        public SymbolArchive(FS.FolderPath root)        
        {
            Root = root;
        }

    }
}