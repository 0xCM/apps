//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = XedRules.FieldKind;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct EncodingOffsets
        {
            [RuleField(K.POS_NOMINAL_OPCODE)]
            public sbyte OpCode;

            [RuleField(K.POS_MODRM)]
            public sbyte ModRm;

            [RuleField(K.POS_SIB)]
            public sbyte Sib;

            [RuleField(K.POS_IMM)]
            public sbyte Imm0;

            [RuleField(K.POS_IMM1)]
            public sbyte Imm1;

            [RuleField(K.POS_DISP)]
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