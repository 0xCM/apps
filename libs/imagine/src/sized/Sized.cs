//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static Refs;
    using static Spans;
    using static Scalars;

    [ApiHost,Free]
    public partial class Sized
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint width<T>()
            => (uint)SizeOf<T>()*8;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint size<T>()
            => (uint)SizeOf<T>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint size<T>(uint count)
            => (uint)SizeOf<T>() * count;

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 8
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static byte bw8<T>(T src)
            where T : unmanaged
                => u8(src);

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 16
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ushort bw16<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return u8(src);
            if(width<T>() == 16)
                return u16(src);
            else if(width<T>() == 32)
                return (ushort)u32(src);
            else
                return (ushort)u64(src);
        }

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 32
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static uint bw32<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return u8(src);
            if(width<T>() == 16)
                return u16(src);
            else if(width<T>() == 32)
                return u32(src);
            else
                return (uint)u64(src);
        }

        [MethodImpl(Inline), Op]
        public static int bw32i(ReadOnlySpan<byte> src)
        {
            var storage = z32i;
            ref var dst = ref @as<byte>(storage);
            var count = min(4,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }

        [MethodImpl(Inline), Op]
        public static uint bw32u(ReadOnlySpan<byte> src)
        {
            var storage = z32;
            ref var dst = ref @as<byte>(storage);
            var count = min(4,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 64
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong bw64<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return u8(src);
            if(width<T>() == 16)
                return u16(src);
            else if(width<T>() == 32)
                return u32(src);
            else
                return u64(src);
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static long bw64i<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return i8(src);
            if(width<T>() == 16)
                return i16(src);
            else if(width<T>() == 32)
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