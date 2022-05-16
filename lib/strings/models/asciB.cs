//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly record struct asci<B> : IComparable<asci<B>>
        where B : unmanaged, IStorageBlock<B>
    {
        public static asci<B> load(ReadOnlySpan<byte> src)
        {
            var data = src;
            var dst = Empty;
            if(data.Length >= StorageSize)
                dst = new asci<B>(@as<byte,B>(data));
            else
                dst = new asci<B>(Storage.block<B>(data));
            return dst;
        }

        [MethodImpl(Inline)]
        public static asci<B> load(ReadOnlySpan<AsciSymbol> src)
            => load(core.recover<AsciSymbol,byte>(src));

        [MethodImpl(Inline)]
        public static asci<B> load(ReadOnlySpan<AsciCode> src)
            => load(core.recover<AsciCode,byte>(src));

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

        public Span<AsciSymbol> Symbols
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
            => Asci.format(Codes);

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

        static uint StorageSize
        {
            [MethodImpl(Inline)]
            get => size<B>();
        }

        [MethodImpl(Inline)]
        public static implicit operator asci<B>(ReadOnlySpan<byte> src)
            => load(src);

        [MethodImpl(Inline)]
        public static implicit operator asci<B>(ReadOnlySpan<AsciSymbol> src)
            => load(src);

       [MethodImpl(Inline)]
        public static implicit operator asci<B>(ReadOnlySpan<AsciCode> src)
            => load(src);

        public static asci<B> Empty => default;
    }
}