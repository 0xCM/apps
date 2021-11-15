//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiPackages : IFileArchive
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public ApiPackages(FS.FolderPath root)
        {
            Root = root;
        }

        public FS.FolderPath ResPackDir()
            => Root + FS.folder("respack");

        public FS.FilePath ResPackLib()
            => ResPackDir() + FS.file("z0.respack", FS.Dll);

        [MethodImpl(Inline)]
        public static implicit operator ApiPackages(FS.FolderPath root)
            => new ApiPackages(root);
    }
}