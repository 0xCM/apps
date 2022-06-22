//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static DocSplitSpec;

    partial class Lines
    {
        public static LineRange split(FS.FilePath src, TextEncodingKind encoding, in DocSplitSpec spec, IReceiver<LineRange> dst)
        {
            using var reader = src.Reader(encoding);
            var counter = 1u;
            var count = spec.LastLine - spec.FirstLine + 1;
            var range = new LineRange(spec.FirstLine, spec.LastLine, alloc<TextLine>(count));
            var lines = range.Edit;
            var i=0;
            var line = reader.ReadLine();
            while(line != null && counter++ <= spec.LastLine && i<count)
            {
                line = reader.ReadLine();
                if(counter >= spec.FirstLine)
                    seek(lines, i++) = new TextLine(counter, line);
            }

            dst.Deposit(range);
            return range;
        }

    }
}