//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiComplete]
    public unsafe sealed class MemoryBank
    {
        public static MemoryBank create(uint capacity)
            => new MemoryBank(capacity);

        Index<SegRef> Segments;

        internal MemoryBank(uint capacity)
        {
            Segments = alloc<SegRef>(capacity);
        }

        [MethodImpl(Inline)]
        public ref SegRef Slot(uint index)
            => ref Segments[index];

        [MethodImpl(Inline), Closures(UnsignedInts)]
        public ref SegRef<T> Slot<T>(uint index)
            where T : unmanaged
                => ref Segments[index].As<T>();

        [MethodImpl(Inline)]
        public ByteSize Size(uint index)
            => Segments[index].Size;

        [MethodImpl(Inline)]
        public Ptr<byte> Ptr(uint index)
            => Segments[index].Pointer<byte>();

        [MethodImpl(Inline)]
        public Ptr<Cell8> Ptr(W8 w, uint index)
            => Segments[index].Pointer<Cell8>();

        [MethodImpl(Inline)]
        public Ptr<Cell16> Ptr(W16 w, uint index)
            => Segments[index].Pointer<Cell16>();

        [MethodImpl(Inline)]
        public Ptr<Cell32> Ptr(W32 w, uint index)
            => Segments[index].Pointer<Cell32>();

        [MethodImpl(Inline)]
        public Ptr<Cell64> Ptr(W64 w, uint index)
            => Segments[index].Pointer<Cell64>();

        [MethodImpl(Inline)]
        public Ptr<Cell128> Ptr(W128 w, uint index)
            => Segments[index].Pointer<Cell128>();

        [MethodImpl(Inline)]
        public Ptr<Cell256> Ptr(W256 w, uint index)
            => Segments[index].Pointer<Cell256>();

        [MethodImpl(Inline)]
        public Ptr<Cell512> Ptr(W512 w, uint index)
            => Segments[index].Pointer<Cell512>();

        [MethodImpl(Inline)]
        public Span<byte> Data(uint index)
            => Segments[index].Edit;

        [MethodImpl(Inline)]
        public Span<Cell8> Data(W8 w, uint index)
            => recover<Cell8>(Segments[index].Edit);

        [MethodImpl(Inline)]
        public Span<Cell16> Data(W16 w, uint index)
            => recover<Cell16>(Segments[index].Edit);

        [MethodImpl(Inline)]
        public Span<Cell32> Data(W32 w, uint index)
            => recover<Cell32>(Segments[index].Edit);

        [MethodImpl(Inline)]
        public Span<Cell64> Data(W64 w, uint index)
            => recover<Cell64>(Segments[index].Edit);

        [MethodImpl(Inline)]
        public Span<Cell128> Data(W128 w, uint index)
            => recover<Cell128>(Segments[index].Edit);

        [MethodImpl(Inline)]
        public Span<Cell256> Data(W256 w, uint index)
            => recover<Cell256>(Segments[index].Edit);

        [MethodImpl(Inline)]
        public Span<Cell512> Data(W512 w, uint index)
            => recover<Cell512>(Segments[index].Edit);
    }
}