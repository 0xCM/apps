//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct @string : IString<string>, IComparable<@string>, IEquatable<@string>
    {
        readonly string Data;

        [MethodImpl(Inline)]
        public @string(string src)
        {
            Data = src;
        }

        public string Content
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Data);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Data);
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
        }

        public string Format()
            => Content;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(@string src)
            => Content.Equals(src.Content);

        [MethodImpl(Inline)]
        public int CompareTo(@string src)
            => Content.CompareTo(src.Content);

        public override int GetHashCode()
            => Content.GetHashCode();

        public override bool Equals(object src)
            => src is @string x && Equals(x);

        public static @string Empty
        {
            [MethodImpl(Inline)]
            get => new @string(EmptyString);
        }

        [MethodImpl(Inline)]
        public static implicit operator @string(string src)
            => new @string(src);

        [MethodImpl(Inline)]
        public static implicit operator string(@string src)
            => src.Content;

        public static bool operator ==(@string a, @string b)
            => a.Equals(b);

        public static bool operator !=(@string a, @string b)
            => !a.Equals(b);
    }
}