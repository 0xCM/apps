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
        public readonly struct FileExt : IFsEntry<FileExt>, IComparable<FileExt>
        {
            public PathPart Name {get;}

            public string Text
            {
                [MethodImpl(Inline)]
                get => Name.Text;
            }

            public uint PathLength
            {
                [MethodImpl(Inline)]
                get => Name.Length;
            }

            public ReadOnlySpan<char> PathData
            {
                [MethodImpl(Inline)]
                get => Name.View;
            }

            [MethodImpl(Inline)]
            public static FileExt operator + (FileExt a, FileExt b)
                => ext(Z0.text.format("{0}.{1}", a.Name, b.Name));

            [MethodImpl(Inline)]
            public static bool operator ==(FileExt a, FileExt b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(FileExt a, FileExt b)
                => !a.Equals(b);

            [MethodImpl(Inline)]
            public FileExt(PathPart name)
                => Name = name;

            [MethodImpl(Inline)]
            public FileExt(PathPart a, PathPart b)
                : this(string.Format("{0}.{1}", a, b))
            {

            }

            [MethodImpl(Inline)]
            public bool Matches(FilePath src)
            {

                var left = Name.View;
                var right = src.Ext.Name.View;
                return left.Same(right);
            }

            [MethodImpl(Inline)]
            public bool Matches(FileName src)
            {
                var left = Name.View;
                var right = src.FileExt.Name.View;
                return left.Same(right);
            }

            [MethodImpl(Inline)]
            public bool Matches(FileExt src)
            {
                var left = Name.View;
                var right = src.Name.View;
                return left.Same(right);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Name.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Name.IsNonEmpty;
            }

            public string SearchPattern
            {
                [MethodImpl(Inline)]
                get => string.Format("*.{0}", Name);
            }

            [MethodImpl(Inline)]
            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();

           public override int GetHashCode()
                => Name.GetHashCode();

            [MethodImpl(Inline)]
            public bool Equals(FileExt src)
                => Name.Equals(src.Name);

            public override bool Equals(object src)
                => src is FileExt x && Equals(x);

            public int CompareTo(FileExt src)
                => Name.CompareTo(src.Name);

            [MethodImpl(Inline)]
            public static implicit operator FileExt((FileExt a, FileExt b) src)
                => src.a + src.b;

            public static FileExt Empty
            {
                [MethodImpl(Inline)]
                get => new FileExt(PathPart.Empty);
            }
       }
    }
}