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

    partial struct Hex
    {
        [Op, Closures(Closure)]
        public static Index<HexLowerCode> digits<T>(in T src, LowerCased @case)
            where T : struct
        {
            var count = size<T>();
            var dst = alloc<HexLowerCode>(count*2);
            digits(src,dst);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void digits<T>(in T src, Span<HexLowerCode> dst)
            where T : struct
        {
            var count = size<T>();
            ref readonly var bytes = ref @as<T,byte>(src);
            var j = count*2 - 1;
            for(var i=0u; i<count; i++)
            {
                ref readonly var d = ref skip(bytes,i);
                seek(dst, j--) = code(n4, LowerCase, d);
                seek(dst, j--) = code(n4, LowerCase, Bytes.srl(d, 4));
            }
        }

        [Op]
        public static Outcome<uint> digits(ReadOnlySpan<char> src, Span<HexDigitValue> dst)
        {
            var j=0u;
            var count = min(src.Length, dst.Length);
            for(var i=0; i<src.Length; i++)
            {
                if(!parse(skip(src,i), out seek(dst,i)))
                    return false;
            }
            return j;
        }

        [MethodImpl(Inline), Op]
        public static void digits(ReadOnlySpan<HexLowerSym> src, Span<HexDigitValue> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = digit(skip(src,i));
        }

        [MethodImpl(Inline), Op]
        public static void digits(ReadOnlySpan<HexUpperSym> src, Span<HexDigitValue> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = digit(skip(src,i));
        }
    }
}