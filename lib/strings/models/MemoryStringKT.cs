//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct MemoryString<K,T> : IMemoryString<K,T>
        where K : unmanaged
        where T : unmanaged
    {
        public readonly K Index {get;}

        public readonly MemoryAddress Address {get;}

        public readonly int Length {get;}

        [MethodImpl(Inline)]
        public MemoryString(K index, MemoryAddress address, int length)
        {
            Index = index;
            Address = address;
            Length = length;
        }

        public uint Size
        {
            [MethodImpl(Inline)]
            get => (uint)Length*size<K>();
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

        public string Format(IStringFormatter formatter)
            => formatter.Format(Bytes);
    }
}