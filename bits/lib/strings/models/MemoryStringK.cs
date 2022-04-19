//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct MemoryString<K> : IMemoryString<K,char>
        where K : unmanaged
    {
        public K Index {get;}

        public MemoryAddress Address {get;}

        public int Length {get;}

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
            get => (uint)Length*size<char>();
        }

        public unsafe ReadOnlySpan<char> Cells
        {
            [MethodImpl(Inline)]
            get => core.cover(Address.Pointer<char>(), Length);
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => cover<byte>(Address, Size);
        }

        public string Format(IStringFormatter formatter)
            => formatter.Format(Bytes);

        public string Format()
            => text.format(Cells);

        public override string ToString()
            => Format();
    }
}