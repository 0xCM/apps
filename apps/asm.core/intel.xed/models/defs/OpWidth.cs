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
                Gpr = default;
                Code = code;
                Bits = bits;
            }

            [MethodImpl(Inline)]
            public OpWidth(ushort bits)
            {
                Gpr = default;
                Code = 0;
                Bits = bits;
            }

            public string Format()
                => Code != 0 ?  XedRender.format(Code) : EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator uint(OpWidth src)
                => core.u32(src);

            public static OpWidth Empty => new OpWidth(0xFFFF);
        }
    }
}