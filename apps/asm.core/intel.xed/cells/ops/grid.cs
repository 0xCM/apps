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
        public static Index<string[]> grid(in RuleTable table)
        {
            var src = XedRules.cells(table);
            var cols = src.Storage.Select(x => x.Count).Max();
            var grid = alloc<string[]>(src.Count);
            for(var j=0; j<src.Count; j++)
            {
                var premise = true;
                var cells = alloc<string>(src[j].Count + 1);
                var ck=0;
                for(var k=0; k<src[j].Count; k++)
                {
                    var cell = src[j][k];

                    if(!cell.IsPremise)
                    {
                        if(premise)
                        {
                            premise  = false;
                            seek(cells,ck++) = "=>";
                        }
                    }

                    seek(cells,ck++) = cell.Format();
                }
                seek(grid,j) = cells;
            }
            return grid;
        }
    }
}