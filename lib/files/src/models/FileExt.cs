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
        [DataType(TypeSyntax.FileExt)]
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
                => ext(Z0.RP.format("{0}.{1}", a.Name, b.Name));

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

            // public bool Matches(FilePath src)
            //     => Matches(src.Ext);

            // public bool Matches(FileName src)
            //     => Matches(src.Ext);

            // public bool Matches(FileExt src)
            // {
            //     var a = Format().ToLower();
            //     var b = Format().ToLower();
            //     var i = text.lastindex(a,Chars.Dot);
            //     var j = text.lastindex(b,Chars.Dot);
            //     if(i >= 0 && j >= 0)
            //         return text.right(a,i) == text.right(b,j);
            //     else
            //         return a == b;
            // }

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