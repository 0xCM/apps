//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using N = N4;
    using A = asci4;
    using S = System.UInt32;

    /// <summary>
    /// Defines an asci code sequence of length 4
    /// </summary>
    public readonly struct asci4 : IAsciSeq<A,N>
    {
        public const uint Size = 4;

        public readonly S Storage;

        [MethodImpl(Inline)]
        public asci4(S src)
            => Storage = src;

        [MethodImpl(Inline)]
        public asci4(string src)
            => Storage = Asci.encode(n,src).Storage;

        public bool IsBlank
        {
            [MethodImpl(Inline)]
            get => IsNull || Equals(Spaced);
        }

        public bool IsNull
        {
            [MethodImpl(Inline)]
            get => Equals(Null);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Storage == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Storage != 0;
        }

        public A Zero
        {
            [MethodImpl(Inline)]
            get => Null;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Asci.length(this);
        }

        public int Capacity
        {
            [MethodImpl(Inline)]
            get => (int)Size;
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Asci.bytes(this);
        }

        public ReadOnlySpan<char> Decoded
        {
            [MethodImpl(Inline)]
            get => Asci.decode(this);
        }

        public TextBlock Text
        {
            [MethodImpl(Inline)]
            get => Asci.format(this);
        }

        [MethodImpl(Inline)]
        public int CompareTo(A src)
            => Text.CompareTo(src.Text);

        [MethodImpl(Inline)]
        public bool Equals(A src)
            => Storage.Equals(src.Storage);

        public override bool Equals(object src)
            => src is A j && Equals(j);

        public override int GetHashCode()
            => Storage.GetHashCode();

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Text;

        public static A Null
        {
            [MethodImpl(Inline)]
            get => new A(default(S));
        }

        public static A Spaced
        {
            [MethodImpl(Inline)]
            get => Asci.init(n);
        }


        [MethodImpl(Inline)]
        public static implicit operator A(string src)
            => new A(src);

        [MethodImpl(Inline)]
        public static implicit operator A(TextBlock src)
            => new A(src.Format());

        [MethodImpl(Inline)]
        public static implicit operator string(A src)
            => src.Text;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<byte>(A src)
            => src.View;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<char>(A src)
            => src.Decoded;

        [MethodImpl(Inline)]
        public static implicit operator A(ushort src)
            => new A(src);

        [MethodImpl(Inline)]
        public static implicit operator A(uint src)
            => new A(src);

        [MethodImpl(Inline)]
        public static implicit operator A(asci2 src)
            => new A(src.Storage);

        [MethodImpl(Inline)]
        public static explicit operator byte(A src)
            => (byte)src.Storage;

        [MethodImpl(Inline)]
        public static explicit operator ushort(A src)
            => (ushort)src.Storage;

        [MethodImpl(Inline)]
        public static explicit operator uint(A src)
            => src.Storage;

        [MethodImpl(Inline)]
        public static bool operator ==(A a, A b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(A a, A b)
            => !a.Equals(b);

        static N n => default;
    }
}