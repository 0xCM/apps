//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using static core;

    partial class Nasm
    {
        [Op]
        public NasmListing ReadListing(FS.FilePath src)
        {
            var flow = Wf.Running(ReadingNasmListing.Format(src));
            var dst = list<NasmListLine>();
            using var reader = src.Utf8Reader();
            var i = 1u;
            while(!reader.EndOfStream)
                dst.Add(new NasmListLine(new TextLine(i++, reader.ReadLine())));
            var lines = dst.ToArray();
            Wf.Ran(flow, ReadNasmListing.Format(lines.Length, src));
            return new NasmListing(src, lines);
        }
    }
}