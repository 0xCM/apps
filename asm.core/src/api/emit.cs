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
        [Op]
        public static Outcome emit(ReadOnlySpan<AsmThumbprint> src, FS.FilePath dst)
        {
            var count = src.Length;
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(AsmRender.format(skip(src,i)));
            return true;
        }

        public static ReadOnlySpan<TextLine> emit(SortedSpan<AsmThumbprint> src, FS.FilePath dst)
        {
            var count = src.Length;
            var lines = span<TextLine>(count);
            using var writer = dst.Writer();
            for(var i=0u; i<count; i++)
            {
                var content = AsmRender.bitstring(src[i]);
                writer.WriteLine(content);
                seek(lines,i) = (i,content);
            }
            return lines;
        }
    }
}