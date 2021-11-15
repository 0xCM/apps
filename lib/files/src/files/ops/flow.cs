//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static Arrow<FileUri> flow(FilePath src, FilePath dst)
            => (src,dst);

        [MethodImpl(Inline), Op]
        public static Arrow<FolderPath> flow(FolderPath src, FolderPath dst)
            => (src,dst);

        [MethodImpl(Inline), Op]
        public static Arrow<FilePath,FolderPath> flow(FilePath src, FolderPath dst)
            => (src,dst);

        [MethodImpl(Inline), Op]
        public static Arrow<FolderPath,FilePath> flow(FolderPath src, FilePath dst)
            => (src,dst);
    }
}