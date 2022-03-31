//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct OpWidth
        {
            public readonly GprWidths Gpr;

            public readonly OpWidthCode Code;

            public readonly ushort Bits;

            [MethodImpl(Inline)]
            public OpWidth(OpWidthCode code, ushort bits)
            {
                Gpr = GprWidths.Empty;
                Code = code;
                Bits = bits;
            }

            [MethodImpl(Inline)]
            public OpWidth(GprWidths gpr)
            {
                Gpr = gpr;
                Code = OpWidthCode.PSEUDO;
                Bits = 0;
            }

            public bool DefinesGprWidth
            {
                [MethodImpl(Inline)]
                get => Gpr.IsNonEmpty;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Code == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Code != 0;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator uint(OpWidth src)
                => core.u32(src);

            [MethodImpl(Inline)]
            public static implicit operator OpWidth(GprWidths src)
                => new OpWidth(src);

            public static OpWidth Empty => new OpWidth(OpWidthCode.INVALID, 0);
        }
    }
}