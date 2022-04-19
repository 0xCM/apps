//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ImagePath : IFile
    {
        public FS.FilePath Path {get;}

        [MethodImpl(Inline)]
        public ImagePath(FS.FilePath src)
        {
            Path = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator ImagePath(FS.FilePath src)
            => new ImagePath(src);

        [MethodImpl(Inline)]
        public static implicit operator FS.FilePath(ImagePath src)
            => src.Path;
    }
}