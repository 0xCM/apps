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
        partial struct TableCalcs
        {
            public static Index<TableDefRow> rows(Index<TableSpec> specs)
            {
                var count = specs.Storage.Select(x => x.RowCount).Sum();
                var buffer = alloc<TableDefRow>(count);
                var k=0u;
                for(var i=0; i<specs.Count; i++)
                {
                    ref readonly var spec = ref specs[i];
                    for(var j=0u; j<spec.RowCount; j++,k++)
                    {
                        ref readonly var row =ref spec[j];
                        ref var dst = ref seek(buffer,k);
                        dst.Seq = k;
                        dst.Index = j;
                        dst.TableId = spec.TableId;
                        dst.Name = spec.TableName;
                        dst.Kind = spec.TableKind;
                        dst.Statement = row.Format();
                    }
                }
                return buffer;
            }
        }
    }
}