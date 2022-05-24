//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using System.IO;

    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static TextLine ReadLine(this StreamReader src, uint number)
            => new TextLine(number, src.ReadLine());

        [Op]
        public static bool ReadLine(this StringReader src, uint number, out TextLine dst)
        {
            var data = src.ReadLine();
            if(data == null)
            {
                dst = TextLine.Empty;
                return false;
            }
            else
            {
                dst = new TextLine(number, data);
                return true;
            }
        }

        public static ReadOnlySpan<TextLine> Lines(this string src, bool keepblank = false, bool trim = true)
            => Z0.Lines.read(src, keepblank, trim);

        [Op]
        public static LineReader Utf8LineReader(this FS.FilePath src)
            => new LineReader(src.Utf8Reader());

        [MethodImpl(Inline), Op]
        public static LineReader ToLineReader(this StreamReader src)
            => new LineReader(src);

        [Op]
        public static LineReader LineReader(this FS.FilePath src, TextEncodingKind encoding)
            => src.Reader(encoding).ToLineReader();
    }

    [ApiHost]
    public readonly partial struct Lines
    {
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