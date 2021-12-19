//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [FileType]
    public abstract class FileType<F,K> : FileType<K>
        where K : unmanaged
        where F : FileType<F,K>,new()
    {
        public static F Instance = new();

        public FileType(K kind, params FS.FileExt[] ext)
            : base(kind, ext)
        {

        }
    }
}