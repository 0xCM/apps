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
        public static Index<RuleSigRow> CalcSigRows(ReadOnlySpan<RuleTableName> src)
        {
            var count = src.Length;
            var dst = alloc<RuleSigRow>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var name = ref skip(src,i);
                ref var row = ref seek(dst,i);
                row.TableKind = name.TableKind;
                row.TableName = name.ShortName;
                row.TableDef = XedPaths.Service.TableDef(name).ToUri();
            }
            var rows = dst.Sort();
            for(var i=0u; i<count; i++)
                seek(rows,i).Seq = i;
            return rows;
        }
   }
}