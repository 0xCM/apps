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
    /// Defines a key-parametric indexed view over <see cref='MethodSlot'/> values
    /// </summary>
    public readonly struct MethodSlots<K>
        where K : unmanaged
    {
        readonly MethodSlot[] Data;

        [MethodImpl(Inline)]
        public MethodSlots(MethodSlot[] slots)
            => Data = slots;

        [MethodImpl(Inline)]
        public ref readonly MethodSlot Lookup(K index)
            => ref skip(Data, uint32(index));

        public ref readonly MethodSlot this[K index]
        {
            [MethodImpl(Inline)]
            get => ref Lookup(index);
        }

        public ref MethodSlot First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        public MethodSlot[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref MethodSlot this[uint index]
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