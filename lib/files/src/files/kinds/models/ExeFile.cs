//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ExeFile : IFsEntry<ExeFile>
    {
        public FS.FilePath Path {get;}

        public FS.PathPart Name
        {
            [MethodImpl(Inline)]
            get => Path.Name;
        }

        [MethodImpl(Inline)]
        public ExeFile(FS.FilePath src)
            => Path = src;

        [MethodImpl(Inline)]
        public static implicit operator ExeFile(FS.FilePath src)
            => new ExeFile(src);

        [MethodImpl(Inline)]
        public static implicit operator FS.FilePath(ExeFile src)
            => src.Path;
    }
}