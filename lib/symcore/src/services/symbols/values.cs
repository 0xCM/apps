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

    partial struct Symbols
    {
        public static Index<LabeledValue<byte>> values8u<E>()
            where E : unmanaged, Enum
                => values<E,byte>();

        public static Index<LabeledValue<sbyte>> values8i<E>()
            where E : unmanaged, Enum
                => values<E,sbyte>();

        public static Index<LabeledValue<ushort>> values16u<E>()
            where E : unmanaged, Enum
                => values<E,ushort>();

        public static Index<LabeledValue<short>> values16i<E>()
            where E : unmanaged, Enum
                => values<E,short>();

        public static Index<LabeledValue<uint>> values32u<E>()
            where E : unmanaged, Enum
                => values<E,uint>();

        public static Index<LabeledValue<int>> values32i<E>()
            where E : unmanaged, Enum
                => values<E,int>();

        public static Index<LabeledValue<ulong>> values64u<E>()
            where E : unmanaged, Enum
                => values<E,ulong>();

        public static Index<LabeledValue<long>> values64i<E>()
            where E : unmanaged, Enum
                => values<E,long>();

        public static Index<LabeledValue<T>> values<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var src = index<E>();
            var count = src.Count;
            var dst = alloc<LabeledValue<T>>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var s = ref src[i];
                seek(dst,i) = new LabeledValue<T>(s.Name.Content, @as<ulong,T>(s.Value));
            }
            return dst;
        }
    }
}