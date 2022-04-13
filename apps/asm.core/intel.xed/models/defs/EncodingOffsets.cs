//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct EncodingOffsets
        {
            [MethodImpl(Inline), Op]
            public static void pack(EncodingOffsets src, Span<byte> dst)
            {
                var offsets = @readonly(bytes(src));
                Bitfields.pack4x4(
                    skip(offsets,0),
                    skip(offsets,1),
                    skip(offsets,2),
                    skip(offsets,3),
                    ref seek16(dst,0)
                    );

                Bitfields.pack4x2(skip(offsets,4), skip(offsets,5), ref seek(dst,4));
            }

            public sbyte OpCode;

            public sbyte ModRm;

            public sbyte Sib;

            public sbyte Imm0;

            public sbyte Imm1;

            public sbyte Disp;

            public bool HasOpCode
            {
                [MethodImpl(Inline)]
                get => OpCode >= 0;
            }

            public bool HasModRm
            {
                [MethodImpl(Inline)]
                get => ModRm >= 0;
            }

            public bool HasSib
            {
                [MethodImpl(Inline)]
                get => Sib >= 0;
            }

            public bool HasImm0
            {
                [MethodImpl(Inline)]
                get => Imm0 >= 0;
            }

            public bool HasImm1
            {
                [MethodImpl(Inline)]
                get => Imm1 >= 0;
            }

            public bool HasDisp
            {
                [MethodImpl(Inline)]
                get => Disp >= 0;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => OpCode < 0 && ModRm < 0 && Sib < 0 && Imm0 < 0 && Imm1 < 0 && Disp < 0;
            }

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