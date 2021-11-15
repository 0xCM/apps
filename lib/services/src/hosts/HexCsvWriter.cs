//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    public class HexCsvWriter : AppService<HexCsvWriter>
    {
        public ByteSize Write(ReadOnlySpan<byte> src, MemoryAddress @base, FS.FilePath dst)
        {
            var rowsize = HexCsv.RowDataSize;
            var formatter = HexDataFormatter.create(@base, rowsize);
            using var writer = dst.AsciWriter();
            writer.WriteLine(string.Concat($"Address".PadRight(12), RP.SpacedPipe, "Data"));
            var offset = MemoryAddress.Zero;
            var lines = 0;
            var blocks = src.Length/rowsize;
            var cells = src.Length%rowsize;
            for(var i=0; i<blocks; i++)
            {
                var data = slice(src,offset,rowsize);
                writer.WriteLine(formatter.FormatLine(data, offset, Chars.Pipe));
                offset += rowsize;
            }

            writer.WriteLine(formatter.FormatLine(slice(src,offset,cells), offset, Chars.Pipe));
            offset += cells;
            return (ulong)offset;
        }
    }
}