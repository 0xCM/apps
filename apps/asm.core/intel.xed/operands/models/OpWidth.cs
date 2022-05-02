//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.OpWidthCode;

    partial struct XedModels
    {
        public readonly struct OpWidths
        {
            // simd_widths = ['b','w','xud', 'qq', 'dq', 'q', 'ps','pd', 'ss', 'sd', 'd', 'm384', 'm512', 'xuq', 'zd']
            public static ReadOnlySpan<OpWidthCode> SimdWidths
                => new OpWidthCode[]{B,W,XUD, QQ, DQ, Q, PS,PD, SS, SD, D, M384, M512, XUQ, ZD};

        }

        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct OpWidth : IComparable<OpWidth>
        {
            public readonly OpWidthCode Code;

            public readonly ushort Bits;

            [MethodImpl(Inline)]
            public OpWidth(OpWidthCode code, ushort bits)
            {
                Code = code;
                Bits = bits;
            }

            [MethodImpl(Inline)]
            public OpWidth(ushort bits)
            {
                Code = 0;
                Bits = bits;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(OpWidth src)
                => ((byte)Code).CompareTo((byte)src.Code);

            [MethodImpl(Inline)]
            public static explicit operator uint(OpWidth src)
                => core.u32(src);

            public static OpWidth Empty => new OpWidth(0xFFFF);
        }
    }
}