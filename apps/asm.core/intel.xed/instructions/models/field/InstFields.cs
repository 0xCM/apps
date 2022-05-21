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
        public readonly struct InstFieldMetrics
        {
            /// <summary>
            /// FieldKind[0,2] ValueKind[3,10] Operator[11,12] Value[16,31]
            /// </summary>
            public static BitPattern Pattern => "fff kkkkkkk oo vvvvvvvvvvvvvvvv";

            public const byte KindWidth = num3.Width;

            public const byte OperatorWidth = InstOperator.Width;

            public const byte ValueKindWidth = num7.Width;

            public const byte ValueWidth = num16.Width;

            public const byte Width = KindWidth + ValueKindWidth + OperatorWidth + ValueWidth;

            public const byte KindOffset = 0;

            public const byte OperatorOffset = KindOffset + KindWidth;

            public const byte ValueKindOffset = OperatorOffset + OperatorWidth;

            public const byte ValueOffset = ValueKindOffset + ValueKindWidth;

            public const uint KindMask = num3.MaxValue << KindOffset;

            public const uint OperatorMask = num2.MaxValue << OperatorOffset;

            public const uint ValueKindMask = num7.MaxValue << ValueKindOffset;

            public const uint ValueMask = num16.MaxValue << ValueOffset;
        }

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