//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct MemoryString<K> : IMemoryString<char>
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

        public string Format(IStringFormatter formatter)
            => formatter.Format(Bytes);

        public string Format()
            => text.format(Cells);

        public override string ToString()
            => Format();
    }
}