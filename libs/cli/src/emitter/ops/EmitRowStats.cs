//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    partial class CliEmitter
    {
        public void EmitRowStats(IApiPack dst)
        {
            var src = ApiMd.Assemblies;
            var seq = 0u;
            var path = dst.Metadata().Table<CliRowStats>();
            var flow = EmittingTable<CliRowStats>(path);
            var formatter = Tables.formatter<CliRowStats>();
            using var writer = path.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var a = ref skip(src,i);
                var rows = CollectRowStats(a,ref seq);
                for(var j=0; j<rows.Length; j++)
                    writer.WriteLine(formatter.Format(skip(rows,j)));
            }

            EmittedTable(flow,seq);
        }

        public ReadOnlySpan<CliRowStats> CollectRowStats(Assembly a, ref uint seq)
        {
            var entries = list<CliRowStats>();
            var reader = CliReader.create(a);
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
                    entry.Seq = seq++;
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