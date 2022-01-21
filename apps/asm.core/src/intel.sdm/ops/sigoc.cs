//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        public static SdmSigOpCode sigoc(in SdmOpCodeDetail src)
            => new SdmSigOpCode(sig(src),asm.opcode(src.OpCodeKey, src.OpCode));
    }
}