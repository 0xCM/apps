//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct VendorManualArchive : IFileArchive
    {
        [MethodImpl(Inline)]
        public static VendorManualArchive create(FS.FolderPath root)
            => new VendorManualArchive(root);

        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public VendorManualArchive(FS.FolderPath root)
        {
            Root = root;
        }

        public FS.FolderPath VendorRoot(string vendor)
            => Root + FS.folder(vendor);

        public FS.Files VendorDocs(string vendor, FS.FileExt ext)
            => VendorRoot(vendor).Files(ext,true);
    }
}