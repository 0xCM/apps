//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly partial struct BfDatasets
    {
        const NumericKind Closure = UnsignedInts;

        public readonly struct PbRender
        {
            public static void render(BpInfo src, uint seq, ITextEmitter dst)
            {
                const string RenderPattern = "{0,-12} | {1}";
                dst.WriteLine();
                dst.AppendLineFormat(RenderPattern, "BitPattern", seq.ToString("D2"));
                dst.WriteLine(RP.PageBreak120);
                dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.Origin), src.Origin);
                dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.Name), src.Name);
                dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.Content), src.Content);
                dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.DataWidth), src.DataWidth);
                dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.MinSize), src.MinSize);
                dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.DataType), src.DataType.DisplayName());
                dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.Descriptor), src.Descriptor);
                dst.AppendLineFormat(RenderPattern, "Segments", EmptyString);
                dst.AppendLine(RP.PageBreak120);
                render(src.Segs, dst);
            }

            public static void render(ReadOnlySpan<BfSegModel> src, ITextEmitter dst, bool header = true)
            {
                var formatter = Tables.formatter<BfSegModel>();
                if(header)
                    dst.AppendLine(formatter.FormatHeader());
                for(var i=0; i<src.Length; i++)
                    dst.AppendLine(formatter.Format(skip(src,i)));
            }

        }

        public static Index<string> gridlines(ReadOnlySpan<byte> src, int rowlen, int? maxbits, bool showrow)
        {
            const byte Pad = 3;
            const string Sep = " | ";
            const char Delimit = Chars.Space;
            var limit = maxbits ?? src.Length;
            var remainder = limit%rowlen;
            var bits = BitRender.render8x8(src);
            var count = (limit/rowlen) + (remainder == 0 ? 0 : 1);
            var buffer = alloc<string>(count);
            var rowidx = 0;
            var k=0u;
            for(int i=0; i<limit; i+=rowlen, k++)
            {
                var remains = bits.Length - i;
                var seglen = min(remains, rowlen);
                var row = slice(bits.View, i, seglen);
                if(showrow)
                    seek(buffer, k) = text.concat($"{rowidx.ToString().PadRight(Pad)}{Sep}", text.format(row.Intersperse(Delimit)));
                else
                    seek(buffer, k) = text.format(row.Intersperse(Delimit));
                rowidx++;
            }

            if(remainder != 0)
            {
                var remains = bits.Length - remainder;
                var seglen = remains;
                var row = slice(bits.View, seglen, remains);
                if(showrow)
                    seek(buffer, k) = text.concat($"{rowidx.ToString().PadRight(Pad)}{Sep}", text.format(row.Intersperse(Delimit)));
                else
                    seek(buffer, k) = text.format(row.Intersperse(Delimit));
            }
            return buffer;
        }
    }
}