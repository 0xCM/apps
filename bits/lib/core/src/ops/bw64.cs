//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static System.Runtime.CompilerServices.Unsafe;

    partial struct core
    {
        static uint _width<T>()
            => (uint)SizeOf<T>()*8;

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 64
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong bw64<T>(T src)
            where T : unmanaged
        {
            if(_width<T>() == 8)
                return u8(src);
            if(_width<T>() == 16)
                return u16(src);
            else if(_width<T>() == 32)
                return u32(src);
            else
                return u64(src);
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static long bw64i<T>(T src)
            where T : unmanaged
        {
            if(_width<T>() == 8)
                return i8(src);
            if(_width<T>() == 16)
                return i16(src);
            else if(_width<T>() == 32)
                return i32(src);
            else
                return i64(src);
        }

        [MethodImpl(Inline), Op]
        public static long bw64i(ReadOnlySpan<byte> src)
        {
            var storage = z64i;
            ref var dst = ref @as<byte>(storage);
            var count = min(8,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }

        [MethodImpl(Inline), Op]
        public static ulong bw64u(ReadOnlySpan<byte> src)
        {
            var storage = z64;
            ref var dst = ref @as<byte>(storage);
            var count = min(8,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }
    }
}