//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        public static BitfieldPattern pattern(string src)
            => BfPatterns.infer(src);

        public static Index<BitfieldPattern> patterns(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var dst = alloc<BitfieldPattern>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = pattern(skip(src,i));
            return dst;
        }

        public static string bitstring(BitfieldPattern pattern, byte data)
        {
            var segs = pattern.Segments.Reverse();
            var count = segs.Count;
            Span<char> buffer = stackalloc char[pattern.Content.Length];
            var j=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var seg = ref segs[i];
                var mask = seg.Mask;
                var width = seg.SegWidth;
                var bits = math.srl(seg.Mask.Apply(data), (byte)seg.MinIndex);
                BitRender.render(bits, ref j, width, buffer);
                seek(buffer, j++) = Chars.Space;
            }
            return new string(buffer);
        }

    }
}