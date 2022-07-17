//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Refs;

    public ref struct MemoryHeap
    {
        [MethodImpl(Inline)]
        internal static Span<T> entry<T>(in MemoryHeap src, uint index)
            where T : unmanaged
        {
            if(index > src.EntryCount - 1)
                return Span<T>.Empty;
            ref readonly var i0 = ref src.Offset(index);
            if(index < src.EntryCount - 1)
                return slice(cells<T>(src), (uint)i0, (uint)(src.Offset(index + 1) - i0));
            else
                return slice(cells<T>(src), (uint)i0);
        }

        [MethodImpl(Inline)]
        internal static Span<T> cells<T>(MemoryHeap src)
            where T : unmanaged
                => recover<T>(src.Data);

        public readonly MemoryAddress Base;

        readonly Span<byte> Data;

        readonly Span<Address32> Offsets;

        public readonly uint EntryCount;

        [MethodImpl(Inline)]
        public MemoryHeap(MemoryAddress @base, Span<byte> data, Span<Address32> offsets)
        {
            Base = @base;
            Data = data;
            Offsets = offsets;
            EntryCount = (uint)offsets.Length;
       }

        [MethodImpl(Inline)]
        public MemoryAddress Address(uint index)
            => Base + Offset(index);

        [MethodImpl(Inline)]
        public MemoryAddress Address(ByteSize size)
            => Base + size;

        [MethodImpl(Inline)]
        public ref Address32 Offset(uint index)
            => ref seek(Offsets, index);

        [MethodImpl(Inline)]
        public ref Address32 Offset(int index)
            => ref seek(Offsets, index);

        [MethodImpl(Inline)]
        public ref byte Cell(Address32 offset)
            => ref seek(Data,(uint)offset);

        [MethodImpl(Inline)]
        public Span<byte> Segment(Address32 offset, uint size)
            => cover(Cell(offset),size);

        [MethodImpl(Inline)]
        public Span<byte> Entry(uint index)
            => entry<byte>(this,index);

        [MethodImpl(Inline)]
        public Span<T> Entry<T>(uint index)
            where T : unmanaged
                => entry<T>(this, index);

        [MethodImpl(Inline)]
        public Span<T> Entry<T>(int index)
            where T : unmanaged
                => entry<T>(this, (uint)index);
    }

}