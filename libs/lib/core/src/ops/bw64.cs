//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static System.Runtime.CompilerServices.Unsafe;

    partial struct core
    {
        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 64
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong bw64<T>(T src)
            where T : unmanaged
        {
            if(Sized.width<T>() == 8)
                return Refs.u8(src);
            if(Sized.width<T>() == 16)
                return Refs.u16(src);
            else if(Sized.width<T>() == 32)
                return Refs.u32(src);
            else
                return Refs.u64(src);
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static long bw64i<T>(T src)
            where T : unmanaged
        {
            if(Sized.width<T>() == 8)
                return Refs.i8(src);
            if(Sized.width<T>() == 16)
                return Refs.i16(src);
            else if(Sized.width<T>() == 32)
                return Refs.i32(src);
            else
                return Refs.i64(src);
        }

        [MethodImpl(Inline), Op]
        public static long bw64i(ReadOnlySpan<byte> src)
        {
            var storage = z64i;
            ref var dst = ref Refs.@as<byte>(storage);
            var count = min(8,src.Length);
            for(var i=0; i<count; i++)
                Refs.seek(dst,i) = Spans.skip(src,i);
            return storage;
        }

        [MethodImpl(Inline), Op]
        public static ulong bw64u(ReadOnlySpan<byte> src)
        {
            var storage = z64;
            ref var dst = ref Refs.@as<byte>(storage);
            var count = min(8,src.Length);
            for(var i=0; i<count; i++)
                Refs.seek(dst,i) = Spans.skip(src,i);
            return storage;
        }
    }
}