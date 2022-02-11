//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct SdmOps
    {
        public static Index<AsmForm> forms(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var dst = alloc<AsmForm>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref skip(src,i);
                seek(dst,i) = form(detail);
            }
            return dst;
        }

        public static AsmForm form(in SdmOpCodeDetail src)
        {
            var result = AsmSigs.parse(src.Sig, out var sig);
            if(result.Fail)
                Errors.Throw(result.Message);

            result = AsmOpCodes.parse(src.OpCode, out var opcode);
            if(result.Fail)
                Errors.Throw(result.Message);

            return AsmForm.define(sig,opcode);
        }
    }
}