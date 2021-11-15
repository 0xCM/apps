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

    partial struct Digital
    {
        [MethodImpl(Inline), Op]
        public static void symbols(ReadOnlySpan<BinaryDigitValue> src, Span<BinaryDigitSym> dst)
        {
            var len = src.Length;
            for(var i = 0u; i<len; i++)
                seek(dst,i) = symbol(skip(src,i));
        }

        [MethodImpl(Inline), Op]
        public static void symbols(ReadOnlySpan<OctalDigitValue> src, Span<OctalDigitSym> dst)
        {
            var len = src.Length;
            for(var i = 0u; i<len; i++)
                seek(dst,i) = symbol(skip(src,i));
        }

        [MethodImpl(Inline), Op]
        public static void symbols(ReadOnlySpan<DecimalDigitValue> src, Span<DecimalDigitSym> dst)
        {
            var len = src.Length;
            for(var i = 0u; i<len; i++)
                seek(dst,i) = symbol(skip(src,i));
        }
    }
}