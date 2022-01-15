//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class Allocation<T> : IDisposable
    {
        IDisposable Allocator;

        public void Dispose()
        {
            Allocator.Dispose();
        }

        protected Allocation(T[] allocated, IDisposable allocator)
        {
            Data = allocated;
            Allocator = allocator;
        }

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