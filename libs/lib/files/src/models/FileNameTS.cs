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
        public readonly struct FileNameTS : ITextual
        {
            readonly FileName Name;

            [MethodImpl(Inline)]
            public FileNameTS(FileName src, Timestamp ts)
                => Name = FS.file(string.Format("{0}.{1}", src.WithoutExtension, ts), src.FileExt);

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();

        }
    }
}
