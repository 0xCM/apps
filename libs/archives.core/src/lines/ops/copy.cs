//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Lines
    {
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