//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = FixedChars;

    [DataWidth(Size*8,Size*8)]
    public struct text31 : ISizedString<text31>
    {
        public const byte MaxLength = 31;

        public const byte PointSize = 1;

        public const uint Size = 32;

        static N31 N => default;

        [StructLayout(LayoutKind.Sequential, Size=32, Pack=1)]
        internal struct StorageType
        {
            ulong A;

            ulong B;

            ulong C;

            ulong D;

            public Span<byte> Bytes
            {
                [MethodImpl(Inline)]
                get => bytes(this);
            }

            public char this[byte i]
            {
                [MethodImpl(Inline)]
                get => (char)Cell(i);
            }

            [MethodImpl(Inline)]
            public ref byte Cell(byte i)
                => ref seek(Bytes,i);

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => D == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => D != 0;
            }

            public static StorageType Empty => default;
        }

        internal StorageType Storage;

        [MethodImpl(Inline)]
        internal text31(in StorageType data)
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
            get => Storage.Cell(31);
        }

        public char this[byte index]
        {
            [MethodImpl(Inline)]
            get => Storage[index];
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
            => api.format(this);

        public override string ToString()
            => Format();

        public bool Equals(text31 src)
            => Storage.Equals(src.Storage);

        public int CompareTo(text31 src)
            => Format().CompareTo(src.Format());

        [MethodImpl(Inline)]
        public static implicit operator text31(string src)
            => api.txt(N,src);

        [MethodImpl(Inline)]
        public static implicit operator text31(ReadOnlySpan<char> src)
            => api.txt(N,src);

        [MethodImpl(Inline)]
        public static implicit operator text31(ReadOnlySpan<byte> src)
            => api.txt(N,src);

        public static text31 Empty => default;
    }
}