//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    public unsafe class PinnedIndex<T> : IBufferAllocation, IIndex<T>
        where T : unmanaged
    {
        readonly GCHandle StorageHandle;

        public T[] Storage {get;}

        readonly T* pData;

        public uint Count {get;}

        [MethodImpl(Inline)]
        public PinnedIndex(T[] content)
        {
            StorageHandle = GCHandle.Alloc(content, GCHandleType.Pinned);
            pData = (T*)StorageHandle.AddrOfPinnedObject().ToPointer();
            Storage = content;
            Count = (uint)content.Length;
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => pData;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => size<T>() * Count;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Size;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => (int)Count;
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => cover<T>(pData, Count);
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => cover<T>(pData, Count);
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref seek(pData,0);
        }
        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(pData, index);
        }


        public void Dispose()
        {
            StorageHandle.Free();
        }

        public string Format()
            => (this as IIndex<T>).Format();

        public override string ToString()
            => Format();
    }
}