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
        public readonly struct FileUri : ITextual, IComparable<FileUri>
        {
            readonly FilePath Source;

            [MethodImpl(Inline)]
            public FileUri(FilePath src)
                => Source = src.Replace("file:///", EmptyString);

            public string Format()
                => string.Format("file:///{0}", Source.Format());

            public string FormatMarkdown(string label = null)
                => string.Format("[{0}]({1})", label ?? Source.FileName.Format(), Format());

            public string MarkdownBullet(string label = null)
                => string.Format("* {0}", Source.ToUri().FormatMarkdown(label));


            public override string ToString()
                => Format();

            public int CompareTo(FileUri src)
                => Source.CompareTo(src.Source);

            [MethodImpl(Inline)]
            public static implicit operator FileUri(FilePath src)
                => new FileUri(src);
        }
    }
}