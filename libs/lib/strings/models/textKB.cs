//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly record struct text<K,B> : IString<text<K,B>,K>
        where B : unmanaged, IStorageBlock<B>
        where K : unmanaged, IEquatable<K>, IComparable<K>
    {
        public static text<K,B> load(ReadOnlySpan<char> src)
        {
            var data = recover<byte>(span(src));
            var dst = Empty;
            if(data.Length >= StorageSize)
                dst = new text<K,B>(@as<byte,B>(data));
            else
                dst = new text<K,B>(Storage.block<B>(data));
            return dst;
        }

        readonly B Data;

        [MethodImpl(Inline)]
        public text(B block)
        {
            Data = block;
        }

        public byte CharSize
        {
            [MethodImpl(Inline)]
            get => (byte)size<K>();
        }

        public uint Capacity
        {
            [MethodImpl(Inline)]
            get => Data.Size/CharSize;
        }

        public ReadOnlySpan<K> Cells
        {
            [MethodImpl(Inline)]
            get => recover<K>(Data.Bytes);
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
            => CharSize == 16 ? recover<char>(Bytes) : Asci.format(recover<AsciCode>(Bytes));

        public int CompareTo(text<K,B> src)
            => Format().CompareTo(src.Format());

        public bool Equals(text<K,B> src)
            => Bytes.SequenceEqual(src.Bytes);

        public string Format()
            => new string(String);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator text<K,B>(B block)
            => new text<K,B>(block);

        static uint StorageSize
        {
            [MethodImpl(Inline)]
            get => size<B>();
        }

        [MethodImpl(Inline)]
        public static implicit operator text<K,B>(string src)
            => load(span(src));

        [MethodImpl(Inline)]
        public static implicit operator text<K,B>(ReadOnlySpan<char> src)
            => load(src);

        public static text<K,B> Empty => default;
    }
}