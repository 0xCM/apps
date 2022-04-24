//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public static KeyedCellRecord record(ushort seq, in KeyedCell cell)
        {
            ref readonly var value = ref cell.Value;
            var dst = KeyedCellRecord.Empty;
            dst.Seq = seq++;
            dst.Index = cell.LinearIndex;
            dst.Table = cell.TableIndex;
            dst.Row = cell.RowIndex;
            dst.Col = cell.CellIndex;
            dst.Logic = cell.Logic;
            dst.Type = value.DataKind;
            dst.Kind = cell.TableKind;
            dst.Rule = cell.Rule;
            dst.Field = cell.Field;
            dst.Value = value;
            dst.Expression = KeyedCell.formatter()(cell);
            dst.Op = cell.Operator();
            return dst;
        }

        public static Index<KeyedCellRecord> records(KeyedCells src)
            => records(src.Tables);

        public static Index<KeyedCellRecord> records(Index<CellTable> src)
        {
            var seq = z16;
            var kCells = src.Select(x => x.CellCount()).Storage.Sum();
            var dst = alloc<KeyedCellRecord>(kCells);
            for(var i=0; i<src.Count; i++)
                records(src[i], ref seq, dst);
            return dst;
        }

        public static Index<KeyedCellRecord> records(in CellTable src)
        {
            var count = src.CellCount();
            var dst = alloc<KeyedCellRecord>(count);
            var seq = z16;
            for(var i=0; i<src.RowCount; i++)
                records(src[i], ref seq, dst);
            return dst;
        }

        public static void records(in CellTable table, ref ushort seq, Span<KeyedCellRecord> dst)
        {
            for(var j=z16; j<table.RowCount; j++)
                records(table[j], ref seq, dst);
        }

        public static void records(in CellRow row, ref ushort seq, Span<KeyedCellRecord> dst)
        {
            for(var k=z16; k<row.CellCount; k++, seq++)
                seek(dst,seq) = record(seq, row[k]);
        }

        public static Index<KeyedCellRecord> records(Index<KeyedCell> cells)
        {
            var count = cells.Count;
            var buffer = alloc<KeyedCellRecord>(count);
            var seq = z16;
            for(var i=z16; i<count; i++)
                seek(buffer,i) = record(i, cells[i]);
            return buffer;
        }
    }
}