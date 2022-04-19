//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [DataType(TypeSyntax.FileUri)]
        public readonly struct FileUri : IFsEntry<FileUri>, ITextual, IComparable<FileUri>
        {
            readonly FilePath Source;

            public PathPart Name
                => Format();

            [MethodImpl(Inline)]
            public FileUri(FilePath src)
                => Source = src.Replace("file:///", EmptyString);

            public FileUri LineRef(uint line)
                =>  new FileUri(path(string.Format("{0}#{1}", this,line)));
            public string Format()
                => string.Format("file:///{0}", Source.Format());

            public string FormatMarkdown(string label = null)
                => string.Format("[{0}]({1})", label ?? Source.FileName.Format(), Format());

            public string MarkdownBullet(string label = null)
                => string.Format("* {0}", Source.ToUri().FormatMarkdown(label));

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Source.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Source.IsNonEmpty;
            }

            public FileUri WithoutLine
            {
                get
                {
                    var src = Source.Format();
                    var i = text.index(src,Chars.Hash);
                    if(i > 0)
                    {
                        return path(text.left(src,i));
                    }
                    else
                        return this;
                }
            }

            public FilePath Path
                => WithoutLine.Source;

            public override string ToString()
                => Format();

            public int CompareTo(FileUri src)
                => Source.CompareTo(src.Source);

            [MethodImpl(Inline)]
            public static implicit operator FileUri(FilePath src)
                => new FileUri(src);

            [MethodImpl(Inline)]
            public static explicit operator FilePath(FileUri src)
                => src.Path;

            public static FileUri Empty => new FileUri(FilePath.Empty);
        }
    }
}