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
            static Index<TableSpec> merge(Index<TableSpec> src)
            {
                var dst = dict<RuleSig,TableSpec>(src.Count);
                for(var i=0u; i<src.Count; i++)
                {
                    ref readonly var table = ref src[i];
                    ref readonly var sig = ref table.Sig;
                    if(sig.IsEmpty)
                        continue;

                    if(dst.TryGetValue(sig, out var t))
                        dst[sig] = t.Merge(table);
                    else
                    {
                        if(!dst.TryAdd(sig,table))
                            Errors.Throw(string.Format("Duplicate sig {0}", sig));
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