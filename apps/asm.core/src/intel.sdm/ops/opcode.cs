//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class IntelSdm
    {
        [Op]
        public static string format(in SdmSigOpCode src)
        {
            var mnemonic = src.Sig.Mnemonic.Format(MnemonicCase.Lowercase);
            if(src.Sig.OperandCount == 0)
            {
                return string.Format("{0}() = {1}", mnemonic, src.OpCode);
            }
            else
            {
                var buffer = CharBlock64.Empty;
                src.Sig.OperandText(ref buffer);
                return string.Format("{0}({1}) = {2}", mnemonic, buffer.Format().Trim(), src.OpCode);
            }
        }

        [MethodImpl(Inline), Op]
        public static ref SdmSigOpCode opcode(in SdmOpCodeDetail src, out SdmSigOpCode dst)
        {
            dst.OpCode = asm.opcode(src.OpCodeKey,src.OpCode);
            dst.Sig = sig(src);
            return ref dst;
        }
    }
}