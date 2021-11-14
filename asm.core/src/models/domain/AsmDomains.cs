//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly partial struct AsmDomains
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit test<T>(in AsmDomain<T> src, uint index)
            where T : unmanaged
                => bits.testbit(skip(bytes(src.Bits), index/8), (byte)(index % 8));

        [Op, Closures(Closure)]
        public static ReadOnlySpan<char> render<T>(in AsmDomain<T> src)
            where T : unmanaged
        {
            var data = serialize(src);
            var storage = CharBlock254.Null;
            var buffer = storage.Data;
            var i=0u;
            var length = BitRender.render8x4(data, ref i, buffer);
            return slice(buffer, 0,length);
        }

        public static string format<T>(in AsmDomain<T> src)
            where T : unmanaged
                => text.format(render(src));

        [MethodImpl(Inline)]
        public static AsmDomain<K,T> domain<K,T>(K kind, T bits, uint? limit = null)
            where K : unmanaged
            where T : unmanaged
                => new AsmDomain<K,T>(kind,bits,limit);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmDomain<T> domain<T>(T bits)
            where T : unmanaged
                => new AsmDomain<T>(bits);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmDomain<T> domain<T>(T bits, uint limit)
            where T : unmanaged
                => new AsmDomain<T>(bits,limit);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<byte> data<T>(in AsmDomain<T> src)
            where T : unmanaged
        {
            align(src.Limit, out var size, out var r);
            return slice(bytes(src.Bits), 0, size);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<byte> serialize<T>(AsmDomain<T> src)
            where T : unmanaged
        {
            var unaligned = !align(src.Limit, out var size, out var r);
            var content = slice(bytes(src.Bits), 0, size);
            ref var b = ref seek(content, size - 1);
            if(unaligned)
                b = bits.trim(b, 0, r);
            return content;
        }

        [MethodImpl(Inline), Op]
        static bit align(uint width, out uint size, out byte r)
        {
            r = (byte)(width % 8);
            bit a = r == 0;
            size = width/8 + (byte)a;
            return a;
        }
    }
}