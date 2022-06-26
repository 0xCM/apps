//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public readonly struct FsEntry : IEquatable<FsEntry>, ITextual
        {
            const string FormatPattern = "{0}: {1}";

            public readonly FS.PathPart Name;

            public readonly ObjectKind Kind;

            [MethodImpl(Inline)]
            public FsEntry(FS.PathPart name, ObjectKind kind)
            {
                Name = name;
                Kind = kind;
            }

            [MethodImpl(Inline)]
            public string Format()
                => string.Format(FormatPattern, Kind, Name);

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

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Name.Hash;
            }

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(FsEntry src)
                => Name.CompareTo(src.Name);

            [MethodImpl(Inline)]
            public bool Equals(FsEntry src)
                => Name.Equals(src.Name);

            public override string ToString()
                => Format();

            public override int GetHashCode()
                => Name.GetHashCode();

            public override bool Equals(object src)
                => src is FsEntry x && Equals(x);

            public static FsEntry Empty => new FsEntry(PathPart.Empty, 0);
        }
    }
}