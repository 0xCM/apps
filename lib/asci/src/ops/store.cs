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

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static void store(ReadOnlySpan<byte> src, char fill, Span<char> dst)
        {
            var count = core.length(src,dst);
            for(var i=0u; i<count; i++)
            {
                ref readonly var next = ref skip(src,i);
                seek(dst,i) = next == 0 ? fill : @char(skip(src,i));
            }
        }

        [MethodImpl(Inline), Op]
        public static int store(in asci2 src, Span<char> dst)
        {
            var data = Asci.cover(src);
            seek(dst,0) = skip(data,0);
            seek(dst,1) = skip(data,1);
            return 2;
        }

        [MethodImpl(Inline), Op]
        public static int store(in asci4 src, Span<char> dst)
        {
            var data = Asci.cover(src);
            seek(dst,0) = skip(data,0);
            seek(dst,1) = skip(data,1);
            seek(dst,2) = skip(data,2);
            seek(dst,3) = skip(data,3);
            return 4;
        }

        [MethodImpl(Inline), Op]
        public static void store(in asci8 src, Span<char> dst)
            => decode(src, ref first(dst));

        [MethodImpl(Inline), Op]
        public static void store(in asci16 src, Span<char> dst)
            => decode(src, ref first(dst));

        [MethodImpl(Inline), Op]
        public static void store(in asci32 src, Span<char> dst)
            => decode(src, ref first(dst));

        [MethodImpl(Inline), Op]
        public static void store(in asci64 src, Span<char> dst)
            => decode(src, ref first(dst));
    }
}