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
        partial struct CellParser
        {
            static Index<TableCriteria> merge(Index<TableCriteria> src)
            {
                var dst = dict<RuleSig,TableCriteria>(src.Count);
                for(var i=0u; i<src.Count; i++)
                {
                    ref readonly var table = ref src[i];
                    if(table.SigKey.IsEmpty)
                        continue;

                    if(dst.TryGetValue(table.SigKey, out var t))
                        dst[table.SigKey] = t.Merge(table);
                    else
                    {
                        if(!dst.TryAdd(table.SigKey,table))
                            Errors.Throw(string.Format("Duplicate sig {0}", table.SigKey));
                    }
                }

                var specs = dst.Values.Array().Sort();
                for(var i=0u; i<specs.Length; i++)
                    seek(specs,i)= seek(specs,i).WithId(i);
                return specs;
            }
        }
    }
}