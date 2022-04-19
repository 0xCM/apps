//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct FileArchive : IFileArchive
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public FileArchive(FS.FolderPath root)
            => Root = root;

        public ListedFiles List()
            => new ListedFiles(Root.EnumerateFiles(true).Array().Mapi((i,x) => new ListedFile(i,x)));

        public Deferred<FS.FilePath> Enumerate()
            => Root.EnumerateFiles(true);

        [MethodImpl(Inline)]
        public static implicit operator FileArchive(FS.FolderPath src)
            => new FileArchive(src);
    }
}