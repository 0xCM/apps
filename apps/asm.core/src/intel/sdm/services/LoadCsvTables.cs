//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Collections.Generic;

    using static Root;
    using static core;
    using static SdmCsvLiterals;

    partial class IntelSdm
    {
        public ReadOnlySpan<Table> LoadCsvTables(ReadOnlySpan<FS.FilePath> src)
        {
            var filecount = src.Length;
            var dst = list<Table>();
            for(var i=0; i<filecount; i++)
                dst.AddRange(LoadCsvTables(skip(src,i)).ToArray());

            return dst.ViewDeposited();
        }

        public ReadOnlySpan<Table> LoadCsvTables(FS.FilePath src)
        {
            var result = Outcome.Success;
            var foundtable = false;
            var parsingrows = false;
            var rowcount = 0;
            var cols = Index<TableColumn>.Empty;
            var rows = list<TableRow>();
            var rowidx = z16;
            var table = TableBuilder.create();
            var tables = list<Table>();
            using var reader = src.LineReader(TextEncodingKind.Utf8);
            while(reader.Next(out var line))
            {
                if((line.IsEmpty || line.StartsWith(TableSeparator)) && !parsingrows)
                    continue;

                if(parsingrows && line.IsEmpty)
                {
                    table.IfNonEmpty(() => tables.Add(table.Emit()));
                    foundtable = false;
                    parsingrows = false;
                    rowcount = 0;
                    continue;
                }

                var content = line.Content;

                if(content.StartsWith(PageTitleMarker))
                {
                    table.WithSource(content.Remove(TableMarker).Trim());
                    continue;
                }

                if(parsingrows)
                {
                    var values = content.SplitClean(ColSep);
                    var valcount = values.Length;

                    if(valcount != cols.Count)
                        Warn($"{valcount} != {cols.Count}");

                    if(valcount != 0)
                    {
                        table.WithRow(values);
                        rowcount++;
                    }
                    continue;
                }

                if(foundtable && !parsingrows)
                {
                    var labels = content.SplitClean(ColSep);
                    if(labels.Length == 0)
                        Warn(string.Format("Expected header"));

                    if(labels.Length != 0)
                    {
                        cols = columns(labels);
                        table.WithColumns(cols);
                        parsingrows = true;
                    }
                }

                if(content.StartsWith(TableMarker))
                {
                    table.Clear();
                    table.WithKind((uint)tablekind(content.Remove(TableMarker).Trim()));
                    foundtable = true;
                }
            }

            table.IfNonEmpty(() => tables.Add(table.Emit()));

            return tables.ViewDeposited();
        }
    }
}