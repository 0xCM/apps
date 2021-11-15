//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Reflection.Metadata.Ecma335;

    using static core;

    partial class CliEmitter
    {
        public void EmitRowStats(ReadOnlySpan<Assembly> src, FS.FilePath dst)
        {
            var count = src.Length;
            var entries = list<CliRowStats>();
            var seq = 0u;
            var flow = Wf.EmittingTable<CliRowStats>(dst);
            var formatter = Tables.formatter<CliRowStats>();
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());

            for(var i=0; i<count; i++)
            {
                ref readonly var a = ref skip(src,i);
                var rows = CollectRowStats(a,ref seq);
                for(var j=0; j<rows.Length; j++)
                    writer.WriteLine(formatter.Format(skip(rows,j)));
            }

            Wf.EmittedTable(flow,seq);
        }

        public ReadOnlySpan<CliRowStats> CollectRowStats(Assembly a, ref uint seq)
        {
            var entries = list<CliRowStats>();
            var reader = CliReader.read(a);
            var counts = reader.GetRowCounts();
            var sizes = reader.GetRowSizes();
            for(byte j=0; j<counts.Count; j++)
            {
                var table = (TableIndex)j;
                var rowcount = counts[table];
                var rowsize = sizes[table];
                if(rowcount != 0)
                {
                    var entry = new CliRowStats();
                    entry.Sequence = seq++;
                    entry.Component = a.GetSimpleName();
                    entry.TableName = table.ToString();
                    entry.TableIndex = j;
                    entry.RowCount = rowcount;
                    entry.RowSize = rowsize;
                    entry.TableSize = rowcount*rowsize;

                    entries.Add(entry);
                }
            }
            return entries.ViewDeposited();
        }
    }
}