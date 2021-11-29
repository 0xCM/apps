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

    /// <summary>
    /// Defines a key-parametric indexed view over <see cref='MemorySeg'/> values
    /// </summary>
    public readonly struct MemorySlots<K>
        where K : unmanaged
    {
        readonly MemorySeg[] Data;

        [MethodImpl(Inline)]
        public MemorySlots(MemorySeg[] slots)
            => Data = slots;

        [MethodImpl(Inline)]
        public ref readonly MemorySeg Lookup(K index)
            => ref skip(Data, uint32(index));

        public ref readonly MemorySeg this[K index]
        {
            [MethodImpl(Inline)]
            get => ref Lookup(index);
        }

        public ref MemorySeg First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        public MemorySeg[] Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref MemorySeg this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }
    }
}