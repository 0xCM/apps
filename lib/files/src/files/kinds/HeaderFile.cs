//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct HeaderFile : IFsEntry<HeaderFile>
    {
        public FS.FilePath Path {get;}

        [MethodImpl(Inline)]
        public HeaderFile(FS.FilePath src)
            => Path = src;

        public FS.PathPart Name
        {
            [MethodImpl(Inline)]
            get => Path.Name;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Path.Format(PathSeparator.BS);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator HeaderFile(FS.FilePath src)
            => new HeaderFile(src);

        public static HeaderFile Empty
        {
            [MethodImpl(Inline)]
            get => new HeaderFile(FS.FilePath.Empty);
        }
    }
}