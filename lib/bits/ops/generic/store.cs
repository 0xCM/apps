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

    partial class gbits
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T store<T>(byte i0, byte i1, in T src, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
            {
                ref var target = ref dst;
                target = @as<byte,T>(bits.store(i0, i1, uint8(src), ref uint8(ref dst)));
                return ref dst;
            }
            else if(typeof(T) == typeof(ushort))
            {
                ref var target = ref dst;
                target = @as<ushort,T>(bits.store(i0, i1, uint16(src), ref uint16(ref dst)));
                return ref dst;
            }
            else if(typeof(T) == typeof(uint))
            {
                ref var target = ref dst;
                target = @as<uint,T>(bits.store(i0, i1, uint32(src), ref uint32(ref dst)));
                return ref dst;
            }
            else if(typeof(T) == typeof(ulong))
            {
                ref var target = ref dst;
                target = @as<ulong,T>(bits.store(i0, i1, uint64(src), ref uint64(ref dst)));
                return ref dst;
            }
            else
                throw no<T>();
         }

    }
}