//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public interface IBufferAllocation<T> : IBufferAllocation
        where T : unmanaged
    {
        ReadOnlySpan<T> Allocated {get;}
    }


    public abstract class Allocation<T> : IBufferAllocation<T>
        where T : unmanaged
    {
        IBufferAllocator Allocator;

        protected Allocation(IBufferAllocator allocator, T[] allocated)
        {
            Allocator = allocator;
            Data = allocated;
            BaseAddress = allocator.BaseAddress;
            Capacity = allocator.Capacity;
        }

        public void Dispose()
        {
            Allocator.Dispose();
        }


        public MemoryAddress BaseAddress {get;}

        public ByteSize Capacity {get;}

        protected Index<T> Data;

        public ReadOnlySpan<T> Allocated
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint Count
        {
            get => Data.Count;
        }

        public ref readonly T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }
    }
}