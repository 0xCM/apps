//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct VendorDocArchive : IFileArchive
    {
        public FS.FolderPath Root {get;}

        public string Vendor {get;}

        public VendorDocArchive(string vendor, FS.FolderPath root)
        {
            Vendor = vendor;
            Root = root;
        }

        public FS.FolderPath DocRoot()
            => Root + FS.folder(Vendor);

        public FS.Files VendorManuals(FS.FileExt ext)
            => DocRoot().Files(ext, true);
    }
}