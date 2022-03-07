//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using T = @string;

    [DataType("string")]
    public readonly struct @string : IString<string>, IComparable<T>, IEquatable<T>
    {
        readonly string Storage;

        [MethodImpl(Inline)]
        public @string(string src)
        {
            Storage = src ?? EmptyString;
        }

        public string Value
        {
            [MethodImpl(Inline)]
            get => Storage ?? EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Storage);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Storage);
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Value.Length;
        }

        public string Format()
            => Value;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(T src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(T src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object src)
            => src is T x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator T(string src)
            => new T(src);

        [MethodImpl(Inline)]
        public static implicit operator string(T src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<char>(T src)
            => src.Data;

        public static bool operator ==(T a, T b)
            => a.Equals(b);

        public static bool operator !=(T a, T b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator <(T a, T b)
            => a.CompareTo(b) < 0;

        [MethodImpl(Inline)]
        public static bool operator >(T a, T b)
            => a.CompareTo(b) > 0;

        [MethodImpl(Inline)]
        public static bool operator <=(T a, T b)
            => a.CompareTo(b) <= 0;

        [MethodImpl(Inline)]
        public static bool operator >=(T a, T b)
            => a.CompareTo(b) >= 0;

        public static T Empty
        {
            [MethodImpl(Inline)]
            get => new T(EmptyString);
        }
    }
}