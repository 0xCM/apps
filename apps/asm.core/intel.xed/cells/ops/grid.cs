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
        public static Index<RuleTableCells> grid(in RuleTable table)
        {
            var src = XedRules.cells(table);
            var cols = src.Storage.Select(x => x.Count).Max();
            var grid = alloc<RuleTableCells>(src.Count);
            for(var j=0; j<src.Count; j++)
            {
                var premise = true;
                var dst = RuleTableCells.Empty;
                var i = z8;
                for(var k=0; k<src[j].Count; k++)
                {
                    var cell = src[j][k];
                    if(!cell.IsPremise)
                    {
                        if(premise)
                        {
                            premise  = false;
                            dst[i] = new(premise, i, table.TableKind, OperatorKind.Impl);
                            i++;
                        }
                    }

                    cell.Index = i;
                    dst[i] = cell;
                    i++;
                    dst.Count = i;
                }
                seek(grid,j) = dst;
            }
            return grid;
        }
    }
}