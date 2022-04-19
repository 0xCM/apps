//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    partial struct FS
    {
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
    }
}