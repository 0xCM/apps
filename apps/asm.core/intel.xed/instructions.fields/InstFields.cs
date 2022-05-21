//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Numbers;
    using static core;

    partial class XedRules
    {
        public class InstFields
        {
            [MethodImpl(Inline)]
            public static InstField define(uint5 src)
            {
                var fk = num(n3, InstFieldKind.BitLit);
                var vk = num(n7, FieldKind.INVALID);
                var op = num(n2, InstOperator.None);
                var value = num(n16, src);
                return Numbers.pack(fk, vk, op, value).Convert<InstField>();
            }

            [MethodImpl(Inline)]
            public static InstField define(Hex8 src)
            {
                var fk = num(n3, InstFieldKind.HexLit);
                var vk = num(n7, FieldKind.INVALID);
                var op = num(n2, InstOperator.None);
                var value = num(n16, src);
                return Numbers.pack(fk, vk, op, value).Convert<InstField>();
            }

            [MethodImpl(Inline)]
            public static InstField define(InstSeg src)
            {
                var fk = num(n3, InstFieldKind.InstSeg);
                var vk = num(n7, src.Field);
                var op = num(n2, InstOperator.None);
                var value = num(n16, z16);
                return Numbers.pack(fk, vk, op, value).Convert<InstField>();
            }

            [MethodImpl(Inline)]
            public static InstField define(CellExpr src)
            {
                var fk = num3.Zero;
                var vk = num(n7, src.Field);
                var op = num2.Zero;
                var value = z16;
                if(src.CellKind == RuleCellKind.EqExpr)
                {
                    fk = num(n3, InstFieldKind.EqExpr);
                    op = num(n2, InstOperator.Eq);
                }
                else if(src.CellKind == RuleCellKind.NeqExpr)
                {
                    fk = num(n3, InstFieldKind.NeqExpr);
                    op = num(n2, InstOperator.Ne);
                }
                return Numbers.pack(fk, vk, op, value).Convert<InstField>();
            }

            [MethodImpl(Inline)]
            public static InstField define(Nonterminal src)
            {
                var fk = num(n3, InstFieldKind.NtCall);
                var vk = num(n7, FieldKind.INVALID);
                var op = num(n2, InstOperator.None);
                var value = num(n16, src);
                return Numbers.pack(fk, vk, op, value).Convert<InstField>();
            }
        }
    }
}