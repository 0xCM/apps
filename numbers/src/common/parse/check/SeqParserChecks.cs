//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using C = AsciCode;

    [ApiHost]
    public class SeqParserChecks : Checker<SeqParserChecks>
    {

        public static ref BufferSegments<T> split<T>(SeqSplitter<T> parser, Span<T> src, out BufferSegments<T> dst)
            where T : unmanaged
        {
            dst = new BufferSegments<T>(src, byte.MaxValue);
            parser.InputCount = (uint)src.Length;
            parser.LastPos = parser.InputCount - 1;
            var segment = ClosedInterval<uint>.Zero;
            while(parser.Unfinished())
            {
                ref readonly var cell = ref core.skip(src, parser.CellPos);
                if(parser.OnLastPos())
                {
                    if(parser.Collecting)
                        dst.Range(parser.SegPos, parser.I0, parser.I1);
                }
                else if(parser.IsDelimiter(cell))
                {
                    if(parser.Collecting)
                    {
                        dst.Range(parser.SegPos, parser.I0, parser.I1 - 1);
                        parser.NextSeg();
                    }

                    parser.I0 = parser.CellPos + 1;
                    parser.I1 = parser.I0;
                    parser.Collecting = true;
                    segment = parser.MarkSegment();
                }
                else if(parser.Collecting)
                    parser.NextPoint();

                parser.NextCell();
            }

            dst.Dispensed = parser.SegPos + 1;
            return ref dst;
        }


        [Op]
        public void RunAll()
        {
            var a = test(n0).Format();
            var b = test(n1).Format();
            var c = test(n2).Format();
        }

        [Op]
        BufferSegments<char> test(N0 n)
        {
            const string Input = "323,3333,33,1";
            const char Delimiter = ',';
            const byte SegCount = 4;

            var parser = Parsers.splitter(Delimiter);
            var input = edit(span(Input));
            split(parser, input, out var segments);
            return segments;
        }

        [Op]
        BufferSegments<ushort> test(N1 n)
        {
            const string Input = "90.33.33.391.385.9";
            const char Delimiter = '.';
            const byte SegCount = 6;

            var parser = Parsers.splitter<ushort>(Delimiter);
            var input = uint16(edit(span(Input)));
            split(parser, input, out var segments);
            return segments;
        }

        [Op]
        BufferSegments<AsciCode> test(N2 n)
        {
            const char Delimiter = '.';
            const byte SegCount = 6;

            var parser = Parsers.splitter(AsciCode.Dot);
            var input = edit(Case2Input);
            split(parser, input, out var segments);
            return segments;
        }

        static ReadOnlySpan<AsciCode> Case2Input
            => new AsciCode[]{C.d9,C.d0,C.Dot, C.d3,C.d3,C.Dot, C.d3,C.d9,C.d1,C.Dot, C.d3,C.d8,C.d5,C.Dot, C.d9};
    }
}