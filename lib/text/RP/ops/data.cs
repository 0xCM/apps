//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RP
    {
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static DataSlot<T> dataslot<T>(byte index, short pad)
            => new DataSlot<T>(index, pad);

        [MethodImpl(Inline), Op]
        public static DataSlot dataslot(byte index, short pad)
            => new DataSlot(index, pad);

        public static DataSlot[] dataslots(short[] padding)
        {
            var count = padding.Length;
            var slots = new DataSlot[count];
            for(var i=0; i<count; i++)
                slots[i] = dataslot((byte)i, padding[i]);
            return slots;
        }
    }
}