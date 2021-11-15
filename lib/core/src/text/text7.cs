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

    using FC = FixedChars;

    public struct text7
    {
        public const byte MaxLength = 7;

        public ulong Storage;

        public byte PointSize
            => 1;

        static N7 N => default;

        [MethodImpl(Inline)]
        internal text7(in ulong data)
        {
            Storage = data;
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => slice(bytes(Storage),0, MaxLength);
        }

        public uint Length
        {
            [MethodImpl(Inline)]
            get => (uint)(Storage >> 56) & 0xFF;
        }

        public string Format()
            => FC.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(text7 src)
            => FC.eq(this,src);

        public override bool Equals(object src)
            => src is text7 n ? Equals(n) : false;

        public override int GetHashCode()
            => (int)FC.hash(this);

        [MethodImpl(Inline)]
        public static bool operator ==(text7 a, text7 b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(text7 a, text7 b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator text7(string src)
            => FC.txt(N,src);

        [MethodImpl(Inline)]
        public static implicit operator text7(ReadOnlySpan<char> src)
            => FC.txt(N,src);

        [MethodImpl(Inline)]
        public static implicit operator text7(char src)
            => FC.txt(N,src);

        public static text7 Empty => default;
    }
}