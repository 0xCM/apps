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
            const byte ColCount = RuleTableRow.ColCount;

            var dst = list<RuleTableRow>();
            var q = 0u;
            for(var i=0u; i<src.Body.Count; i++)
            {
                ref readonly var expr = ref src.Body[i];
                if(expr.IsEmpty || expr.IsVacuous || expr.IsNull || expr.IsError)
                    continue;

                var m = z8;
                var row = RuleTableRow.Empty;
                row.TableKind = src.TableKind;
                row.TableName = src.Sig.Name;
                row.RowIndex = q++;

                for(var k=0; k<expr.Premise.Count; k++)
                    assign(m++, src.TableKind, expr.Premise[k], ref row);

                m = ColCount/2;

                for(var k=0; k<expr.Consequent.Count; k++)
                    assign(m++, src.TableKind, expr.Consequent[k], ref row);

                dst.Add(row);
            }
            return new RuleTableRows(src.Sig,  dst.ToArray());
        }

        [MethodImpl(Inline), Op]
        static void assign(byte i, RuleTableKind tk,  in RuleCriterion src, ref RuleTableRow dst)
            => dst[i] = new RuleTableCell(tk, i,src);
    }
}