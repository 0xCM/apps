//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using System.IO;

    [ApiHost]
    public readonly partial struct Lines
    {

        [MethodImpl(Inline)]
        public static LineSegment segment(LineNumber src, ushort min, ushort max)
            => new LineSegment(src,min,max);

        public static Fence<char> RangeFence
            => (Chars.LBracket, Chars.RBracket);

        public const string RangeDelimiter = "..";

        public const char IdentitySep = Chars.Colon;

        public static Fence<char> CountFence
            => (Chars.LParen, Chars.RParen);

        [MethodImpl(Inline), Op]
        public static uint lines(string src, Span<string> dst, bool keepblank = false, bool trim = true)
        {
            var k=0u;
            var capacity = (uint)dst.Length;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null && k<capacity)
                {
                    if(text.blank(next))
                        if(keepblank)
                            seek(dst,k++) = next;
                    else
                        seek(dst, k++) = trim ? text.trim(next) : next;
                    next = reader.ReadLine();
                }
            }
            return k;
        }
        [Op]
        public static LineCount linecount(FS.FilePath src)
            => (src, Lines.count(src.ReadBytes()));

        [Op]
        public static Index<LineCount> linecounts(ReadOnlySpan<FS.FilePath> src)
        {
            var dst = bag<LineCount>();
            iter(src, path => dst.Add(linecount(path)), true);
            return dst.ToArray().Sort();
        }

        [Op]
        public static uint linecount(FS.FilePath src, TextEncodingKind encoding)
        {
            var counter = 0u;
            using var reader = src.Reader(encoding);
            var line = reader.ReadLine();
            while(line != null)
            {
                counter++;
                line = reader.ReadLine();
            }

            return counter;
        }

        const NumericKind Closure = UnsignedInts;

        static MsgPattern<Count,LineNumber,string> BadLineNumber => "BadLineNumber(counter{0} != line{1}, content{2})";

        public static Outcome<uint> copy(FS.FilePath src, FS.FilePath dst, Pair<TextEncodingKind> encoding)
        {
            var outcome = Outcome.Success;
            using var reader = src.LineReader(encoding.Left);
            using var writer = dst.Writer(encoding.Right);
            var counter = 1u;
            while(reader.Next(out var line))
            {
                if(counter != line.LineNumber)
                {
                    var msg = BadLineNumber.Format(counter, line.LineNumber, line.Content);
                    outcome = (false,msg);
                    break;
                }
                writer.WriteLine(line);
                counter++;
            }
            return (true, counter-1);
        }
    }
}