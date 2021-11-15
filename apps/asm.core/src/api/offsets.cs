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

    partial struct asm
    {
        public static HexVector32 offsets(ReadOnlySpan<ProcessAsmRecord> src)
        {
            var count = src.Length;
            var buffer = alloc<Hex32>(count);
            offsets(src, buffer);
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static uint offsets(ReadOnlySpan<ProcessAsmRecord> src, Span<Hex32> dst)
        {
            var count = (uint)src.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i).GlobalOffset;
            return count;
        }
    }
}