//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct MemoryString : IMemoryString<MemoryString,char>
    {
        public readonly MemoryAddress Address;

        public readonly int Length;

        public readonly uint Size;

        [MethodImpl(Inline)]
        public MemoryString(MemoryAddress address, int length)
        {
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Address.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(MemoryString src)
            => Address == src.Address && Size == src.Size;

        MemoryAddress IAddressable.Address
            => Address;

        public string Format(IStringFormatter formatter)
            => formatter.Format(Bytes);

        public string Format()
            => text.format(Cells);

        public override string ToString()
            => Format();

        public int CompareTo(MemoryString src)
            => Cells.CompareTo(src.Cells, StringComparison.InvariantCulture);

    }
}