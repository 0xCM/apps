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
        public static RuleTableRows rows(in RuleTable src)
        {
            var dst = list<RuleTableRow>();
            for(byte i=0; i<src.Expressions.Count; i++)
            {
                ref readonly var expr = ref src.Expressions[i];
                var m=z8;
                var row = RuleTableRow.Empty;
                row.RowIndex = i;
                for(var k=0; k<expr.Premise.Count; k++)
                    assign(m++, expr.Premise[k], ref row);

                m = 6;

                for(var k=0; k<expr.Consequent.Count; k++)
                    assign(m++, expr.Consequent[k], ref row);

                dst.Add(row);
            }
            return new RuleTableRows(src.Name,  dst.ToArray());
        }

        static void assign(byte i, in RuleCriterion src, ref RuleTableRow dst)
        {
            var col = new RuleTableCell(i,src);
            switch(i)
            {
                case 0:
                    dst.Col0P = col;
                break;
                case 1:
                    dst.Col1P = col;
                break;
                case 2:
                    dst.Col2P = col;
                break;
                case 3:
                    dst.Col3P = col;
                break;
                case 4:
                    dst.Col4P = col;
                break;
                case 5:
                    dst.Col5P = col;
                break;
                case 6:
                    dst.Col0C = col;
                break;
                case 7:
                    dst.Col1C = col;
                break;
                case 8:
                    dst.Col2C = col;
                break;
                case 9:
                    dst.Col3C = col;
                break;
                case 10:
                    dst.Col4C = col;
                break;
                case 11:
                    dst.Col5C = col;
                break;
            }
        }
    }
}