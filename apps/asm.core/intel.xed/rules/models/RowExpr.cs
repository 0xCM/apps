//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RowExpr
        {
            readonly Index<RuleCell> Cells;

            public RowExpr(Index<RuleCell> src)
            {
                Cells = src;
            }

            public string Format()
            {
                var dst = text.emitter();
                var count = Cells.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var cell = ref Cells[i];

                    if(i != 0)
                        dst.Append(Chars.Space);

                    if(i == count - 1 && cell.IsOperator)
                        break;

                    dst.Append(XedRender.format(cell.Value));
                }

                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}