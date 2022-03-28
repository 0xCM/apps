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

            public Imm Imm0;

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
                const string RenderPattern = "{0,-8} | {1,-5} | {2,-5} | {3,-5} | {4,-5} | {5,-5}";
                var header = string.Format(RenderPattern, nameof(OpCode), nameof(ModRm), nameof(Sib), nameof(Imm0), nameof(Imm1), nameof(Disp));
                var content = string.Format(RenderPattern,
                    XedRender.format(OpCode),
                    Offsets.HasModRm ? ModRm.Format() : EmptyString,
                    Offsets.HasSib ? Sib.Format() : EmptyString,
                    Offsets.HasImm0 ? Imm0.Format() : EmptyString,
                    Offsets.HasImm1 ? Imm1.Format() : EmptyString,
                    Offsets.HasDisp ? Disp.Format() : EmptyString
                    );
                return string.Format("{0}{1}{2}",header, RP.Eol, content);
            }

            public override string ToString()
                => Format();
        }
    }
}