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
        [StructLayout(StructLayout,Pack=1,Size =4),DataWidth(Width)]
        public readonly struct InstField
        {
            public const byte KindWidth = num3.Width;

            public const byte Width = KindWidth + num7.Width + RuleOperator.Width;

            const byte ValueOffset = 16;

            const byte ValueWidth = 16;

            uint Data
            {
                [MethodImpl(Inline)]
                get => @as<InstField,uint>(this);
            }

            num16 Value
            {
                [MethodImpl(Inline)]
                get => (ushort)(Data >> ValueOffset);
            }

            public InstFieldKind FieldKind
            {
                [MethodImpl(Inline)]
                get =>((num3)Data).Convert<InstFieldKind>();
            }

            public FieldKind ValueKind
            {
                [MethodImpl(Inline)]
                get => ((num7)Data).Convert<FieldKind>();
            }

            public RuleOperator Operator
            {
                get => default;
            }

            [MethodImpl(Inline)]
            public static InstField define(uint5 src)
            {

                return default;
            }

            [MethodImpl(Inline)]
            public static InstField define(Hex8 src)
            {
                return default;
            }

            [MethodImpl(Inline)]
            public static InstField define(InstSeg src)
            {
                return default;
            }

            [MethodImpl(Inline)]
            public static InstField define(CellExpr src)
            {
                return default;
            }

            [MethodImpl(Inline)]
            public static InstField define(Nonterminal src)
            {
                return default;
            }

            [MethodImpl(Inline)]
            public static implicit operator uint(InstField src)
                => src.Data;

        }
    }
}