//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct EncodingOffsets
        {
            public sbyte OpCode;

            public sbyte ModRm;

            public sbyte Sib;

            public sbyte Imm0;

            public sbyte Imm1;

            public sbyte Disp;

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            static EncodingOffsets empty()
            {
                var dst = new EncodingOffsets();
                dst.OpCode = -1;
                dst.ModRm = -1;
                dst.Sib = -1;
                dst.Imm0 = -1;
                dst.Imm1 = -1;
                dst.Disp = -1;
                return dst;
            }

            public static EncodingOffsets Empty
            {
                [MethodImpl(Inline)]
                get => empty();
            }
        }
    }
}