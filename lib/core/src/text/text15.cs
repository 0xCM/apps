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

    public struct text15
    {
        public const byte MaxLength = 15;

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

            public static StorageType Empty => default;
        }

        internal StorageType Storage;

        public byte PointSize
            => 1;

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

        public string Format()
            => FC.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator text15(string src)
            => FC.txt(N,src);

        [MethodImpl(Inline)]
        public static implicit operator text15(ReadOnlySpan<char> src)
            => FC.txt(N,src);

        public static text15 Empty => default;
    }
}