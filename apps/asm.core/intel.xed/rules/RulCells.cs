//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    partial class XedRules
    {
        public class RuleCells : SortedLookup<RuleSig,Index<RuleCell>>
        {
            public static RuleCells create(Dictionary<RuleSig,Index<RuleCell>> src, string desc)
            {
                var _src = src.ToConcurrentDictionary();
                var dst = new RuleCells(_src);
                var data = tables(_src);
                var metrics = new CellMetrics();
                metrics.TableCount = (ushort)src.Count;
                metrics.CellCount = _src.Values.Map(x => x.Count).Sum();
                metrics.RowCounts = data.Select(x => (ushort)x.RowCount);
                metrics.RowCount = data.Select(x => x.RowCount).Storage.Sum();
                dst._Metrics = metrics;
                dst._Tables = data;
                dst._Description = desc;
                dst._Records = records(data);
                return dst;
            }

            public static RuleCellRecord record(ushort seq, in RuleCell cell)
            {
                ref readonly var value = ref cell.Value;
                var dst = RuleCellRecord.Empty;
                dst.Seq = seq++;
                dst.Index = cell.Key.Index;
                dst.Table = cell.TableIndex;
                dst.Row = cell.RowIndex;
                dst.Col = cell.CellIndex;
                dst.Logic = cell.Logic;
                dst.Type = value.CellKind;
                dst.Kind = cell.TableKind;
                dst.Rule = cell.Rule.TableName;
                dst.Field = cell.Field;
                dst.Value = value;
                dst.Expression = RuleCell.formatter()(cell);
                dst.Op = cell.Operator();
                return dst;
            }

            static Index<RuleCellRecord> records(RuleCells src)
                => records(src.Tables);

            static Index<RuleCellRecord> records(Index<CellTable> src)
            {
                var seq = z16;
                var kCells = src.Select(x => x.CellCount()).Storage.Sum();
                var dst = alloc<RuleCellRecord>(kCells);
                for(var i=0; i<src.Count; i++)
                    records(src[i], ref seq, dst);
                return dst;
            }

            public static Index<RuleCellRecord> records(in CellTable src)
            {
                var count = src.CellCount();
                var dst = alloc<RuleCellRecord>(count);
                var seq = z16;
                for(var i=0; i<src.RowCount; i++)
                    records(src[i], ref seq, dst);
                return dst;
            }

            public static void records(in CellTable table, ref ushort seq, Span<RuleCellRecord> dst)
            {
                for(var j=z16; j<table.RowCount; j++)
                    records(table[j], ref seq, dst);
            }

            public static void records(in CellRow row, ref ushort seq, Span<RuleCellRecord> dst)
            {
                for(var k=z16; k<row.CellCount; k++, seq++)
                    seek(dst,seq) = record(seq, row[k]);
            }

            static Index<CellTable> tables(ConcurrentDictionary<RuleSig,Index<RuleCell>> src)
                => src.Keys.Array().Select(sig => table(src,sig)).Index().Sort();

            static CellTable table(ConcurrentDictionary<RuleSig,Index<RuleCell>> src, RuleSig sig)
            {
                var dst = CellTable.Empty;
                if(src.TryGetValue(sig, out var cells))
                {
                    var tix = z16;
                    if(cells.Count !=0)
                    {
                        tix = cells.First.TableIndex;
                        var rows = cells.GroupBy(x => x.RowIndex).Select(x => (new CellRow(sig, tix, x.Key, x.ToIndex()))).ToIndex();
                        dst = new CellTable(sig, tix, rows);
                    }
                }
                return dst;
            }

            Index<CellTable> _Tables;

            CellMetrics _Metrics;

            string _Description;

            Index<RuleCellRecord> _Records;

            RuleCells(ConcurrentDictionary<RuleSig,Index<RuleCell>> src)
                : base(src)
            {

            }

            public RuleCells(ConcurrentDictionary<RuleSig,Index<RuleCell>> src, Index<CellTable> tables, CellMetrics metrics, string desc)
                : base(src)
            {
                _Description = desc;
                _Tables = tables;
                _Metrics = metrics;
            }

            /// <summary>
            /// Describes the dataset
            /// </summary>
            public ref readonly string Description
            {
                [MethodImpl(Inline)]
                get => ref _Description;
            }

            /// <summary>
            /// Specifies dataset characteristics
            /// </summary>
            public ref readonly CellMetrics Metrics
            {
                [MethodImpl(Inline)]
                get => ref _Metrics;
            }

            /// <summary>
            /// Specifies the indexed tables
            /// </summary>
            public ref readonly Index<CellTable> Tables
            {
                [MethodImpl(Inline)]
                get => ref _Tables;
            }

            public ref readonly Index<RuleCellRecord> Records
            {
                [MethodImpl(Inline)]
                get => ref _Records;
            }

            public Index<RuleCell> Flatten()
                => flatten(this);
        }
   }
}