//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = SizedText;

    public readonly record struct asci<B> : IString<asci<B>,AsciSymbol>
        where B : unmanaged, IStorageBlock<B>
    {
        readonly B Data;

        [MethodImpl(Inline)]
        public asci(B block)
        {
            Data = block;
        }

        public uint Capacity
        {
            [MethodImpl(Inline)]
            get => Data.Size/8;
        }

        public ReadOnlySpan<AsciSymbol> Cells
        {
            [MethodImpl(Inline)]
            get => recover<AsciSymbol>(Data.Bytes);
        }

        public Span<AsciCode> Codes
        {
            [MethodImpl(Inline)]
            get => recover<AsciCode>(Data.Bytes);
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Data.Bytes;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public ReadOnlySpan<char> String
            => Asci.format(Cells);

        public int CompareTo(asci<B> src)
            => Format().CompareTo(src.Format());

        public bool Equals(asci<B> src)
            => Bytes.SequenceEqual(src.Bytes);

        public string Format()
            => new string(String);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator asci<B>(B block)
            => new asci<B>(block);

        public static uint StorageSize
        {
            [MethodImpl(Inline)]
            get => size<B>();
        }

        [MethodImpl(Inline)]
        public static implicit operator asci<B>(ReadOnlySpan<byte> src)
            => api.load<B>(src);

        [MethodImpl(Inline)]
        public static implicit operator asci<B>(ReadOnlySpan<AsciSymbol> src)
            => api.load<B>(src);

        [MethodImpl(Inline)]
        public static implicit operator asci<B>(ReadOnlySpan<AsciCode> src)
            => api.load<B>(src);

        public static asci<B> Empty => default;
    }
}