//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    using static Root;
    using static core;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static BinaryCode asci(string src)
            => Encoding.ASCII.GetBytes(src);

        [MethodImpl(Inline), Op]
        public static string asci(ReadOnlySpan<byte> src)
            => Encoding.ASCII.GetString(src);

        [MethodImpl(Inline), Op]
        public static uint asci(in TextBlock src, Span<byte> dst)
        {
            var chars = src.View;
            var count = (uint)min(chars.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (byte)skip(chars, i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static void asci(ReadOnlySpan<byte> src, Span<char> dst)
            => Encoding.ASCII.GetChars(src,dst);

        [MethodImpl(Inline), Op]
        public static unsafe string asci(byte* pSrc, ByteSize size)
            => Encoding.ASCII.GetString(pSrc,size);
    }
}