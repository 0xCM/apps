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
        /// <summary>
        /// FieldKind[0,2] ValueKind[3,10] Operator[11,12] Value[16,31]
        /// </summary>
        [StructLayout(StructLayout,Pack=1,Size=4),DataWidth(Width)]
        public readonly struct InstField
        {
            internal const byte KindWidth = num3.Width;

            const byte OperatorWidth = InstOperator.Width;

            const byte ValueKindWidth = num7.Width;

            const byte ValueWidth = num16.Width;

            public const byte Width = KindWidth + ValueKindWidth + OperatorWidth + ValueWidth;

            const byte KindOffset = 0;

            const byte OperatorOffset = KindOffset + KindWidth;

            const byte ValueKindOffset = OperatorOffset + OperatorWidth;

            const byte ValueOffset = ValueKindOffset + ValueKindWidth;

            const uint KindMask = num3.MaxValue << KindOffset;

            const uint OperatorMask = num2.MaxValue << OperatorOffset;

            const uint ValueKindMask = num7.MaxValue << ValueKindOffset;

            const uint ValueMask = num16.MaxValue << ValueOffset;

            num32 Storage
            {
                [MethodImpl(Inline)]
                get => @as<InstField,num32>(this);
            }

            num16 ValueData
            {
                [MethodImpl(Inline)]
                get => (num16)(Storage & ValueMask >> ValueOffset);
            }

            public InstFieldKind Kind
            {
                [MethodImpl(Inline)]
                get =>(Storage & KindMask >> KindOffset).Convert<InstFieldKind>();
            }

            public InstOperator Operator
            {
                [MethodImpl(Inline)]
                get => (Storage & OperatorMask >> OperatorOffset).Convert<InstOperator>();
            }

            public FieldKind ValueKind
            {
                [MethodImpl(Inline)]
                get => (Storage & ValueKindMask >> ValueKindOffset).Convert<FieldKind>();
            }

            [MethodImpl(Inline)]
            public static InstField define(uint5 src)
            {
                var fk = InstFieldKind.BitLit;
                var vk = FieldKind.INVALID;
                var op = InstOperator.None;
                var value = (ushort)src;

                return default;
            }

            [MethodImpl(Inline)]
            public static InstField define(Hex8 src)
            {
                var fk = InstFieldKind.HexLit;
                var vk = FieldKind.INVALID;
                var op = InstOperator.None;
                var value = (ushort)src;
                return default;
            }

            [MethodImpl(Inline)]
            public static InstField define(InstSeg src)
            {
                var fk = InstFieldKind.InstSeg;
                var op = InstOperator.None;
                var vk = src.Field;
                var value = z16;
                return default;
            }

            [MethodImpl(Inline)]
            public static InstField define(CellExpr src)
            {
                var fk = InstFieldKind.None;
                var op = InstOperator.None;
                var vk = src.Field;
                var value = z16;
                if(src.CellKind == RuleCellKind.EqExpr)
                {
                    fk = InstFieldKind.EqExpr;
                    op = InstOperator.Eq;
                }
                else if(src.CellKind == RuleCellKind.NeqExpr)
                {
                    fk = InstFieldKind.NeqExpr;
                    op = InstOperator.Ne;
                }

                return default;
            }

            [MethodImpl(Inline)]
            public static InstField define(Nonterminal src)
            {
                var fk = InstFieldKind.NtCall;
                var op = InstOperator.None;
                var vk = FieldKind.INVALID;
                var value = (ushort)src;

                return default;
            }


            [MethodImpl(Inline)]
            public T Value<T>()
                where T : unmanaged
                    => ValueData.Convert<T>();

            [MethodImpl(Inline)]
            public static implicit operator uint(InstField src)
                => src.Storage;

        }
    }
}