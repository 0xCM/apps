//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class XedRules
    {
        public struct EncodingExtract
        {
            public AsmHexCode Code;

            public EncodingOffsets Offsets;

            public Hex8 OpCode;

            public ModRm ModRm;

            public Sib Sib;

            public Imm Imm;

            public Imm Imm1;

            public Disp Disp;

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Offsets.IsEmpty;
            }

            public static EncodingExtract Empty
            {
                get
                {
                    var dst = default(EncodingExtract);
                    dst.Offsets = EncodingOffsets.Empty;
                    return dst;
                }
            }

            public string Format()
            {
                const string RP0 = "{0,-8} | {1,-5} | {2,-5} | {3,-12} | {4,-12}";
                const string RP1 = "{0,-8} | {1,-5} | {2,-5} | {3,-12} | {4,-12} | {5,-5}";

                var pattern = Offsets.HasImm1 ? RP1 : RP0;
                var header = string.Format(pattern, nameof(OpCode), nameof(ModRm), nameof(Sib), nameof(Imm), nameof(Disp), nameof(Imm1));
                var content = string.Format(pattern,
                    XedRender.format(OpCode),
                    Offsets.HasModRm ? ModRm.Format() : EmptyString,
                    Offsets.HasSib ? Sib.Format() : EmptyString,
                    Offsets.HasImm0 ? Imm.Format() : EmptyString,
                    Offsets.HasDisp ? Disp.Format() : EmptyString,
                    Offsets.HasImm1 ? Imm1.Format() : EmptyString
                    );
                return string.Format("{0}{1}{2}",header, RP.Eol, content);
            }

            public override string ToString()
                => Format();
        }
    }
}