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