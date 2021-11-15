//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial interface IEnvPaths
    {
        VendorDocArchive VendorDocs()
            => new VendorDocArchive(Env.VendorDocs);

        VendorManualArchive VendorManuals()
            => VendorDocs().Manuals();

        FS.FilePath List(string name, FS.FileExt ext)
            => ListRoot() + FS.file(name, ext);

        FS.FilePath Doc(string name, FS.FileExt ext)
            => DbDocRoot() + FS.file(name, ext);
    }
}