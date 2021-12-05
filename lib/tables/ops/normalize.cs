//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;

    partial struct Tables
    {
        [Op]
        public static Outcome<Count> normalize(Asset src, string delimiter, ReadOnlySpan<byte> widths, FS.FilePath dst)
        {
            var data = text.utf8(src.Bytes());
            var parseResult = TextGrids.parse(data, out var doc);
            if(parseResult.Fail)
                return parseResult;

            return normalize(data, delimiter, widths, dst);
        }

        [Op]
        public static Outcome<Count> normalize(string data, string delimiter, ReadOnlySpan<byte> widths, FS.FilePath dst)
        {
            var result = TextGrids.parse(data, out var doc);
            var fieldCount = widths.Length;
            var header = doc.Header.ToRowHeader(delimiter, widths);
            if(header.CellCount != fieldCount)
                return (false,Tables.FieldCountMismatch.Format(fieldCount, header.CellCount));

            using var writer = dst.Writer();
            writer.WriteLine(header.Format());

            var rows = doc.Rows;
            var count = rows.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(rows,i);
                var cells = row.Cells;
                if(row.CellCount != fieldCount)
                    return (false, Tables.FieldCountMismatch.Format(fieldCount, row.CellCount));

                for(var j=0; j<fieldCount; j++)
                {
                    ref readonly var cell = ref skip(cells,j);
                    var formatted = cell.Format(-skip(widths,j));
                    if(j != 0)
                        formatted = string.Format("{0}{1}",delimiter, formatted);
                    if(j != fieldCount - 1)
                        writer.Write(formatted);
                    else
                        writer.WriteLine(formatted);
                }
            }

            return (true, count);
        }
    }
}