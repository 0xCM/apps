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
        public static Index<RuleSigRow> CalcSigRows(ConcurrentDictionary<RuleTableKind,Index<RuleTable>> src)
        {
            var sigs = src.Values.Array().SelectMany(x => x).Select(x => x.Sig).Distinct().Sort();
            var dst = alloc<RuleSigRow>(sigs.Length);
            for(var i=0u; i<sigs.Length; i++)
            {
                ref var row = ref seek(dst,i);
                ref readonly var sig = ref skip(sigs,i);
                row.Seq = i;
                row.TableKind = sig.TableKind;
                row.TableName = sig.ShortName;
                row.TableDef = XedPaths.Service.TableDef(sig);
            }
            return dst;
        }
   }
}