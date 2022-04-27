//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static CellExpr expr(OperatorKind op, CellValue value)
            => new (op,value);

        static string expr(Index<RuleCell> src)
        {
            var count = src.Count;
            var dst = text.buffer();
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);

                if(i == count - 1 && src[i].IsOperator)
                    break;

                dst.Append(src[i].Format());
            }
            return dst.Emit();
        }

        public static string expr(in CellRow src)
            => expr(src.Cells);
    }
}