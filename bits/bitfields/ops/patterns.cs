//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        public static BitPattern pattern(BfOrigin origin, string src)
            => BitPatterns.infer(origin, src);

        public static Index<BitPattern> patterns(BfOrigin origin, ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var dst = alloc<BitPattern>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = pattern(origin, skip(src,i));
            return dst;
        }

        public static string bitstring(BitPattern pattern, byte data)
        {
            var segs = pattern.Segments.Reverse();
            var count = segs.Count;
            Span<char> buffer = stackalloc char[pattern.Content.Length];
            var j=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var seg = ref segs[i];
                var mask = seg.Mask;
                var width = seg.Width;
                var bits = math.srl(seg.Mask.Apply(data), (byte)seg.MinPos);
                BitRender.render(bits, ref j, width, buffer);
                seek(buffer, j++) = Chars.Space;
            }
            return new string(buffer);
        }

    }
}