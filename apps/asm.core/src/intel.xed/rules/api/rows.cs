//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public static RuleTableRows rows(in RuleTable src)
        {
            var dst = list<RuleTableRow>();
            for(var i=0u; i<src.Body.Count; i++)
            {
                ref readonly var expr = ref src.Body[i];
                var m=z8;
                var row = RuleTableRow.Empty;
                row.TableKind = src.TableKind;
                row.TableName = src.Sig.Name;
                row.RowIndex = i;

                for(var k=0; k<expr.Premise.Count; k++)
                    assign(m++, expr.Premise[k], ref row);

                m = RuleTableRow.ColCount/2;

                for(var k=0; k<expr.Consequent.Count; k++)
                    assign(m++, expr.Consequent[k], ref row);

                dst.Add(row);
            }
            return new RuleTableRows(src.Sig,  dst.ToArray());
        }

        [MethodImpl(Inline), Op]
        static void assign(byte i, in RuleCriterion src, ref RuleTableRow dst)
            => dst[i] = new RuleTableCell(i,src);
    }
}