//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FileType<K> : FileType, IFileType<K>
        where K : unmanaged
    {
        public FileType(K kind, params FS.FileExt[] ext)
            : base(kind.ToString(), ext)
        {
            Kind = kind;
        }

        public K Kind {get;}
    }
}