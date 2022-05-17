//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct MemoryString<K,T> : IMemoryString<T>
        where K : unmanaged
        where T : unmanaged
    {
        public readonly MemoryAddress Address;

        public readonly int Length;

        public readonly uint Size;

        [MethodImpl(Inline)]
        public MemoryString(K index, MemoryAddress address, int length)
        {
            Address = address;
            Length = length;
            Size = (uint)length*size<char>();
        }

        public unsafe ReadOnlySpan<T> Cells
        {
            [MethodImpl(Inline)]
            get => core.cover(Address.Pointer<T>(), Length);
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => cover<byte>(Address, Size);
        }

        MemoryAddress IMemoryString.Address
            => Address;

        public string Format(IStringFormatter formatter)
            => formatter.Format(Bytes);
    }
}