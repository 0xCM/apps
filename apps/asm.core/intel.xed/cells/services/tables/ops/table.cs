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
        partial class RuleTables
        {
            static RuleCells dataset(Dictionary<RuleSig,Index<RuleCell>> src, string desc)
            {
                var cdict = src.ToConcurrentDictionary();
                var tables = CellTables.calc(cdict.Keys.Select(sig => table(cdict,sig)).Array());
                var sigcells = core.pairings(src.Map(x => core.paired(x.Key,x.Value)));
                return new RuleCells(sigcells, tables, records(tables), desc);
            }

            static CellTable table(ConcurrentDictionary<RuleSig,Index<RuleCell>> src, RuleSig rule)
            {
                var dst = CellTable.Empty;
                if(src.TryGetValue(rule, out var cells))
                {
                    var i = z16;
                    if(cells.Count !=0)
                    {
                        i = cells.First.TableIndex;
                        var rows = cells.GroupBy(x => x.RowIndex).Select(x => (new CellRow(rule, i, x.Key, x.ToIndex()))).ToIndex();
                        dst = new CellTable(rule, i, rows);
                    }
                }
                return dst;
            }

            static Index<RuleCellRecord> records(CellTables src)
            {
                var seq = z16;
                var dst = alloc<RuleCellRecord>(src.CellCount);
                for(var i=0; i<src.TableCount; i++)
                {
                    ref readonly var table = ref src[i];
                    for(var j=z16; j<table.RowCount; j++)
                    {
                        ref readonly var row = ref table[j];
                        for(var k=0; k<row.CellCount; k++, seq++)
                            seek(dst,seq) = record(seq, row[k]);
                    }
                }
                return dst;
            }

            static RuleCellRecord record(ushort seq, in RuleCell cell)
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
                dst.Expression = XedRender.format(cell.Value);
                dst.Op = cell.Operator();
                return dst;
            }
        }
    }
}