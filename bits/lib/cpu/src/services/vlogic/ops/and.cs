//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    using BL = ByteLogic;

    partial class vlogic
    {
        [MethodImpl(Inline), And, Closures(Closure)]
        public static void and<T>(in T a, in T b, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.and(u8(a), u8(b), ref u8(dst));
            else if(typeof(T) == typeof(ushort))
                and(w, in a, in b, ref dst);
            else if(typeof(T) == typeof(uint))
                and(w, 4, 8, in a, in b, ref dst);
            else if(typeof(T) == typeof(ulong))
                and(w, 16, 4, in a, in b, ref dst);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), And, Closures(Closure)]
        public static Vector128<T> and<T>(W128 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vand(gcpu.vload(w, a), gcpu.vload(w, b));

        [MethodImpl(Inline), And, Closures(Closure)]
        public static Vector256<T> and<T>(W256 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vand(gcpu.vload(w, a), gcpu.vload(w, b));

        [MethodImpl(Inline), And, Closures(Closure)]
        public static void and<T>(W128 n, in T a, in T b, ref T dst)
            where T : unmanaged
                => gcpu.vstore(and(n, a, b), ref dst);

        [MethodImpl(Inline), And, Closures(Closure)]
        public static void and<T>(W128 w, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i<vcount; i++, offset += blocklen)
                and(w, skip(a, offset), skip(b, offset), ref seek(dst, offset));
        }

        [MethodImpl(Inline), And, Closures(Closure)]
        public static void and<T>(W256 w, in T a, in T b, ref T dst)
            where T : unmanaged
                => gcpu.vstore(and(w, in a, in b), ref dst);

        [MethodImpl(Inline), And, Closures(Closure)]
        public static void and<T>(W256 n, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                and(n, skip(in a, offset), in skip(in b, offset), ref seek(dst, offset));
        }
   }
}