//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct SdmOps
    {
        public static AsmForms forms(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var dst = new AsmForms();
            iter(src, d => dst.Include(d));
            return dst;
        }

        public static Outcome form(in SdmOpCodeDetail src, out AsmForm dst)
        {
            dst = AsmForm.Empty;
            var result = AsmSigs.parse(src.Sig, out var sig);
            if(result.Fail)
                return result;

            result = AsmOpCodes.parse(src.OpCode, out var opcode);
            if(result.Fail)
                return result;

            dst = new AsmForm("x", sig, opcode);
            return result;
        }
    }
}