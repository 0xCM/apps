//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    partial interface IEnvPaths
    {
        FS.FolderPath CatalogRoot()
            => DbRoot() + FS.folder(catalogs);

        FS.FolderPath AsmCatalogRoot()
            => CatalogRoot() + FS.folder(asm);

        FS.FilePath AsmCatalogTable<T>()
            where T : struct
                => AsmCatalogRoot() + FS.file(TableId<T>(), FS.Csv);
    }
}