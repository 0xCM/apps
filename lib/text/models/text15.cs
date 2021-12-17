//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    using FC = FixedChars;

    public struct text15 : ISizedString<text15>
    {
        public const byte MaxLength = 15;

        public const byte PointSize = 1;

        public static W128 W => default;

        static N15 N => default;

        [StructLayout(LayoutKind.Sequential, Size=16, Pack=1)]
        internal struct StorageType
        {
            ulong A;

            ulong B;

            public Span<byte> Bytes
            {
                [MethodImpl(Inline)]
                get => bytes(this);
            }

            [MethodImpl(Inline)]
            public ref byte Cell(byte i)
                => ref seek(Bytes,i);

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => A == 0 && B == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => A != 0 || B != 0;
            }

            public uint Hash
            {
                [MethodImpl(Inline)]
                get => alg.hash.combine(alg.hash.calc(A), alg.hash.calc(B));
            }

            [MethodImpl(Inline)]
            public bool Equals(StorageType src)
                => A == src.A && B == src.B;

            public static StorageType Empty => default;
        }

        internal StorageType Storage;

        [MethodImpl(Inline)]
        internal text15(in StorageType data)
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
            get => Storage.Cell(15);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Storage.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Storage.IsNonEmpty;
        }

        public uint CharCapacity => MaxLength;

        public BitWidth CharWidth => PointSize*8;

        public BitWidth StorageWidth => size<StorageType>();

        public string Format()
            => FC.format(this);

        public override string ToString()
            => Format();

        public bool Equals(text15 src)
            => Storage.Equals(src.Storage);
        public int CompareTo(text15 src)
            => Format().CompareTo(src.Format());

        public override int GetHashCode()
            => (int)Storage.Hash;

        public override bool Equals(object src)
            => src is text15 x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator text15(string src)
            => FC.txt(N,src);

        [MethodImpl(Inline)]
        public static implicit operator text15(ReadOnlySpan<char> src)
            => FC.txt(N,src);

        [MethodImpl(Inline)]
        public static bool operator ==(text15 a, text15 b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(text15 a, text15 b)
            => !a.Equals(b);

        public static text15 Empty => default;
    }
}