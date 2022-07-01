//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct MemoryString<K> : IMemoryString<MemoryString<K>, char>
        where K : unmanaged
    {
        public readonly K Kind;

        public readonly MemoryAddress Address;

        public readonly int Length;

        public readonly uint Size;

        [MethodImpl(Inline)]
        public MemoryString(K kind, MemoryAddress address, int length)
        {
            Kind = kind;
            Address = address;
            Length = length;
            Size = (uint)length*size<char>();
        }

        public unsafe ReadOnlySpan<char> Cells
        {
            [MethodImpl(Inline)]
            get => cover(Address.Pointer<char>(), Length);
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => cover<byte>(Address, Size);
        }

        MemoryAddress IAddressable.Address
            => Address;

        int IByteSeq.Length
            => Length;

        int IByteSeq.Capacity
            => Length;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Address.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public string Format(IStringFormatter formatter)
            => formatter.Format(Bytes);

        public string Format()
            => text.format(Cells);

        public override string ToString()
            => Format();

        public bool Equals(MemoryString<K> src)
            => Bytes.SequenceEqual(src.Bytes);

        public int CompareTo(MemoryString<K> src)
            => Cells.CompareTo(src.Cells, StringComparison.InvariantCulture);

    }
}