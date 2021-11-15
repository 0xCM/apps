//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a legal identifier within a given context
    /// </summary>
    [DataType]
    public readonly struct Identifier : IIdentifier<Identifier>
    {
        readonly string Data;

        public string Content
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public Identifier(string src)
            => Data = src ?? EmptyString;

        [MethodImpl(Inline)]
        public Identifier(Name src)
            => Data = src;

        public string Text
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public Name Name
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => string.IsNullOrEmpty(Content);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Content.GetHashCode();
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Content.Length;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        [MethodImpl(Inline)]
        public int CompareTo(Identifier src)
            => Content.CompareTo(src.Content);

        [MethodImpl(Inline)]
        public bool Equals(Identifier src)
            => Content.Equals(src.Content);

        public override string ToString()
            => Content;

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is Identifier n && Equals(n);

        [MethodImpl(Inline)]
        public static implicit operator Identifier(string src)
            => new Identifier(src);

        [MethodImpl(Inline)]
        public static implicit operator Identifier(Name src)
            => new Identifier(src);

        [MethodImpl(Inline)]
        public static implicit operator Name(Identifier src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator string(Identifier src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<char>(Identifier src)
            => src.Content;

        [MethodImpl(Inline)]
        public static bool operator <(Identifier x, Identifier y)
            => x.CompareTo(y) < 0;

        [MethodImpl(Inline)]
        public static bool operator <=(Identifier x, Identifier y)
            => x.CompareTo(y) <= 0;

        [MethodImpl(Inline)]
        public static bool operator >(Identifier x, Identifier y)
            => x.CompareTo(y) > 0;

        [MethodImpl(Inline)]
        public static bool operator >=(Identifier x, Identifier y)
            => x.CompareTo(y) >= 0;

        [MethodImpl(Inline)]
        public static bool operator ==(Identifier x, Identifier y)
            => x.Content == y.Content;

        [MethodImpl(Inline)]
        public static bool operator !=(Identifier x, Identifier y)
            => x.Content != y.Content;

        public static Identifier Empty
        {
            [MethodImpl(Inline)]
            get => new Identifier(Name.Empty);
        }
    }
}