//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType("NamedKind")]
    public readonly struct NamedKind : IComparable<NamedKind>, IEquatable<NamedKind>
    {
        public readonly Name Name;

        [MethodImpl(Inline)]
        public NamedKind(Name src)
            => Name = src;

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

        [MethodImpl(Inline)]
        public string Format()
            => Name;

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Name.GetHashCode();
        }


        [MethodImpl(Inline)]
        public int CompareTo(NamedKind src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(NamedKind src)
            => Name.Equals(src.Name);


        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is NamedKind n && Equals(n);

        [MethodImpl(Inline)]
        public static implicit operator NamedKind(string src)
            => new NamedKind(src);

        [MethodImpl(Inline)]
        public static implicit operator string(NamedKind src)
            => src.Name;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<char>(NamedKind src)
            => src.Name;

        [MethodImpl(Inline)]
        public static bool operator <(NamedKind x, NamedKind y)
            => x.CompareTo(y) < 0;

        [MethodImpl(Inline)]
        public static bool operator <=(NamedKind x, NamedKind y)
            => x.CompareTo(y) <= 0;

        [MethodImpl(Inline)]
        public static bool operator >(NamedKind x, NamedKind y)
            => x.CompareTo(y) > 0;

        [MethodImpl(Inline)]
        public static bool operator >=(NamedKind x, NamedKind y)
            => x.CompareTo(y) >= 0;

        [MethodImpl(Inline)]
        public static bool operator ==(NamedKind x, NamedKind y)
            => x.Name == y.Name;

        [MethodImpl(Inline)]
        public static bool operator !=(NamedKind x, NamedKind y)
            => x.Name != y.Name;

        public static NamedKind Empty
        {
            [MethodImpl(Inline)]
            get => new NamedKind(EmptyString);
        }
    }
}