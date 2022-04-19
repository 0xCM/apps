//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TextFile : IFsEntry<TextFile>
    {
        public FS.FilePath Path {get;}

        public FS.PathPart Name
        {
            [MethodImpl(Inline)]
            get => Path.Name;
        }

        [MethodImpl(Inline)]
        public TextFile(FS.FilePath src)
            => Path = src;

        [MethodImpl(Inline)]
        public static implicit operator TextFile(FS.FilePath src)
            => new TextFile(src);

        [MethodImpl(Inline)]
        public static implicit operator FS.FilePath(TextFile src)
            => src.Path;
    }
}