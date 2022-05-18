//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        public static string bitstring(in BpDef src, ulong value)
        {
            var segments = segs(src.Content);
            var count = segments.Count;
            Span<char> buffer = stackalloc char[src.Content.Length];
            var j=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var seg = ref segments[i];
                var bits = math.srl(seg.Mask.Apply(value), (byte)seg.MinPos);
                BitRender.render((ushort)bits, ref j, seg.Width, buffer);
                seek(buffer, j++) = Chars.Space;
            }
            return new string(buffer);
        }
    }
}