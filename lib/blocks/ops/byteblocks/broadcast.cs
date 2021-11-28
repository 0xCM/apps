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
    using static vcore;

    partial class ByteBlocks
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ByteBlock4 broadcast<T>(in T src, W32 w)
            where T : unmanaged
        {
            ref var dst8 = ref alloc(n4, out ByteBlock4 dst);
            if(typeof(T) == typeof(byte))
            {
                ref var x = ref dst8;
                ref readonly var y = ref u8(src);
                seek(x,0) = y;
                seek(x,1) = y;
                seek(x,2) = y;
                seek(x,3) = y;
                return dst;
            }
            else if(typeof(T) == typeof(ushort))
            {
                ref var x = ref u16(dst8);
                ref readonly var y = ref u16(src);
                seek(x,0) = y;
                seek(x,1) = y;
                return dst;
            }
            else if(typeof(T) == typeof(uint))
            {
                ref var x = ref u32(dst8);
                ref readonly var y = ref u32(src);
                seek(x,0) = y;
                return dst;
            }
            else if(typeof(T) == typeof(ulong))
            {
                ref var x = ref u32(dst8);
                ref readonly var y = ref u64(src);
                seek(x,0) = (uint)y;
                return dst;
            }
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ByteBlock8 broadcast<T>(in T src, W64 w)
            where T : unmanaged
        {
            var x = vbroadcast(w128, uint8(src));
            vstore(x, ref alloc(n16, out var dst));
            return @as<ByteBlock16,ByteBlock8>(dst);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ByteBlock16 broadcast<T>(in T src, W128 w)
            where T : unmanaged
        {
            var x = vbroadcast(w, uint8(src));
            vstore(x, ref alloc(n16, out var dst));
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ByteBlock32 broadcast<T>(in T src, W256 w)
            where T : unmanaged
        {
            var x = vbroadcast(w, uint8(src));
            vstore(x, ref alloc(n32, out var dst));
            return dst;
        }
    }
}