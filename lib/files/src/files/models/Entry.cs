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

            [MethodImpl(Inline)]
            public bool Equals(FsEntry src)
                => Name.Equals(src.Name);

            public override string ToString()
                => Format();

            public override int GetHashCode()
                => Name.GetHashCode();

            public override bool Equals(object src)
                => src is FsEntry x && Equals(x);
        }
    }
}