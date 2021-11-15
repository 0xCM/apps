//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType]
    public readonly struct Name : IDataTypeComparable<Name>
    {
        readonly string Data;

        [MethodImpl(Inline)]
        public Name(string src)
            => Data = src ?? EmptyString;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => string.IsNullOrEmpty(Data);
        }

        public string Text
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Content
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => Content;
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

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
        }

        [MethodImpl(Inline)]
        public int CompareTo(Name src)
            => Content.CompareTo(src.Content);

        [MethodImpl(Inline)]
        public bool Equals(Name src)
            => string.Equals(Data, src.Data);


        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is Name n && Equals(n);

        [MethodImpl(Inline)]
        public static implicit operator Name(string src)
            => new Name(src);

        [MethodImpl(Inline)]
        public static implicit operator string(Name src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<char>(Name src)
            => src.Content;

        [MethodImpl(Inline)]
        public static bool operator <(Name x, Name y)
            => x.CompareTo(y) < 0;

        [MethodImpl(Inline)]
        public static bool operator <=(Name x, Name y)
            => x.CompareTo(y) <= 0;

        [MethodImpl(Inline)]
        public static bool operator >(Name x, Name y)
            => x.CompareTo(y) > 0;

        [MethodImpl(Inline)]
        public static bool operator >=(Name x, Name y)
            => x.CompareTo(y) >= 0;

        [MethodImpl(Inline)]
        public static bool operator ==(Name x, Name y)
            => x.Data == y.Data;

        [MethodImpl(Inline)]
        public static bool operator !=(Name x, Name y)
            => x.Data != y.Data;

        public static Name Empty
        {
            [MethodImpl(Inline)]
            get => new Name(EmptyString);
        }
    }
}