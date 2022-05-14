//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct MemoryString : IMemoryString<uint,char>
    {
        public readonly uint Index {get;}

        public readonly MemoryAddress Address {get;}

        public readonly int Length {get;}

        [MethodImpl(Inline)]
        public MemoryString(uint index, MemoryAddress address, int length)
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
            get => cover(Address.Pointer<char>(), Length);
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