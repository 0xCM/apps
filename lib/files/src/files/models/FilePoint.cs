//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct FS
    {
        public readonly struct FilePoint
        {
            public FS.FilePath Path {get;}

            public LineOffset Location {get;}

            [MethodImpl(Inline)]
            public FilePoint(FS.FilePath path, LineOffset loc)
            {
                Path = path;
                Location = loc;
            }

            public string Format()
                => string.Format("{0}:{1}:{2}", Path.Format(PathSeparator.BS), Location.Line, Location.Offset);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator FS.FilePoint((FS.FilePath path, LineOffset loc) src)
                => new FS.FilePoint(src.path,src.loc);

            public static FilePoint Empty
            {
                [MethodImpl(Inline)]
                get => new FilePoint(FilePath.Empty, LineOffset.Empty);
            }
        }
    }
}